namespace Source2Framework.Models
{
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Core.Plugin;

    public abstract class BaseService<T> : IBaseService<T>
        where T : class, IService
    {
        public required BasePlugin Plugin;

        public required ServiceManager Manager;

        protected readonly ILogger<T> Logger;

        protected readonly PluginContext PluginContext;

        public readonly string ServiceName;

        public bool Initialized { get; set; } = false;

        private bool ShutdownMarked { get; set; } = false;

        public BaseService(ILogger<T> logger, IPluginContext pluginContext)
        {
            this.Logger = logger;
            this.PluginContext = (pluginContext as PluginContext)!;

            this.ServiceName = typeof(T).Name;
        }

        ~BaseService()
        {
            if (this.ShutdownMarked)
                return;

            this.ShutdownInternal(false);
        }

        public void InitializeInternal(IServiceManager serviceManager, bool hotReload)
        {
            if (this.Initialized)
                return;

            this.Logger.LogInformation("Initializing service '{0}'", this.ServiceName);

            this.Plugin = (this.PluginContext.Plugin as BasePlugin)!;
            this.Manager = (serviceManager as ServiceManager)!;
            
            try
            {
                this.Initialize(hotReload);
                this.Initialized = true;
                this.Manager.OnServiceInitializedInternal(this, hotReload);
            } catch (Exception ex)
            {
                this.Logger.LogError("Failed to initialize service '{0}' ({1})", this.ServiceName, ex.Message);
                this.Manager.OnServiceExceptionInternal(this, ex);
            }
        }

        public void ShutdownInternal(bool hotReload)
        {
            this.Logger.LogInformation("Releasing '{0}'", this.ServiceName);
            this.ShutdownMarked = true;
            this.Shutdown(hotReload);
            this.Manager.OnServiceShutdownInternal(this, false);
            this.Initialized = false;
        }

        protected TPlugin GetPluginAs<TPlugin>() where TPlugin : BasePlugin, IPlugin
        {
            return (TPlugin)this.Plugin;
        }

        public virtual void OnServicesInitialized(bool hotReload)
            { }

        public virtual void OnServiceInitialized(IService service)
            { }

        public virtual void OnServiceShutdown(IService service)
            { }

        public virtual void OnServiceException(IService service, Exception exception)
            { }

        public virtual void Initialize(bool hotReload)
            { }

        public virtual void Shutdown(bool hotReload)
            { }
    }
}
