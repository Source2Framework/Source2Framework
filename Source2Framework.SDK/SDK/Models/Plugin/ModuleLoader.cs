namespace Source2Framework.Models
{
    using CounterStrikeSharp.API.Core.Capabilities;

    public class ModuleLoader : IDisposable
    {
        public readonly PluginCapability<IFramework> CoreInterface = new PluginCapability<IFramework>("S2F:Core");

        public IFramework? Framework { get; set; }

        public IS2FModule? InnerModule { get; set; }

        public void Attach(IS2FModule plugin, bool hotReload)
        {
            this.InnerModule = plugin;
            IFramework? framework = CoreInterface.Get();

            if (framework != null)
            {
                this.Framework = framework;

                if (!this.Framework.IsInitialized)
                {
                    this.Framework.OnCoreReady += (IFramework framework, bool inHotReload) =>
                    {
                        this.InnerModule.OnCoreReady(framework, inHotReload);
                    };
                } else
                {
                    this.InnerModule.OnCoreReady(framework, hotReload);
                }
            } else
            {
                this.InnerModule.Logger.LogError("Source2Framework is required for this plugin");
            }
        }

        public void Dispose()
        {
            if (this.Framework == null || this.InnerModule == null)
                return;

            this.Framework.OnCoreReady -= this.InnerModule.OnCoreReady;
        }
    }
}
