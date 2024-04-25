namespace Source2Framework.Services.Framework
{
    using CounterStrikeSharp.API;
    using CounterStrikeSharp.API.Core.Capabilities;
    using CounterStrikeSharp.API.Core.Plugin;

    using Source2Framework.Models;

    public sealed partial class FrameworkService : BaseService<FrameworkService>, IFramework
    {
        public ServiceManager Services { get => base.Manager; }

        public INetworkServerService NetworkServerService { get; }

        public readonly PluginCapability<IFramework> Framework = new PluginCapability<IFramework>("S2F:Core");

        public event Action<IFramework, bool>? OnCoreReady;

        public bool IsInitialized { get; private set; }

        public FrameworkService(ILogger<FrameworkService> logger, IPluginContext pluginContext, INetworkServerService networkServerService) : base(logger, pluginContext)
        {
            this.NetworkServerService = networkServerService;
        }

        public override void Initialize(bool hotReload)
        {
            Capabilities.RegisterPluginCapability(this.Framework, () => this as IFramework);

            Server.NextWorldUpdate(() =>
            {
                this.OnCoreReady?.Invoke(this, hotReload);
                this.IsInitialized = true;
            });
        }

        public override void Shutdown(bool hotReload)
        {
            this.IsInitialized = false;
        }

        public void RegisterService<TService>(IService service, bool hotReload = false)
            where TService : class, IService
        {
            this.Services.RegisterService<TService>(service, hotReload);
        }

        public bool IsServiceAvailable<T>()
            where T : class, IService
        {
            return this.Services.IsServiceAvailable<T>();
        }

        public T? GetService<T>()
            where T : class, IService
        {
            return this.Services.GetService<T>();
        }
    }
}
