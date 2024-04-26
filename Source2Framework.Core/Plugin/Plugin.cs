namespace Source2Framework
{
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Core.Attributes;

    using Source2Framework.Models;
    using Source2Framework.Services.Framework;

    [MinimumApiVersion(214)]
    public sealed partial class Plugin : BasePlugin, IPluginConfig<PluginConfig>
    {
        public required PluginConfig Config { get; set; } = new PluginConfig();

        public required ServiceManager ServiceManager;

        public Plugin
            (
                ServiceManager serviceManager,
                FrameworkService frameworkService
            )
        {
            (this.ServiceManager = serviceManager).RegisterServices
            (
                frameworkService
            );
        }

        public void OnConfigParsed(PluginConfig config)
        {
            if (config.Version != Config.Version)
            {
                this.Logger.LogWarning("Configuration version mismatch (Expected: {0} | Current: {1})", this.Config.Version, config.Version);
            }

            this.Config = config;
        }

        public override void Load(bool hotReload)
        {
            this.ServiceManager.InitializeServices(hotReload);
        }

        public override void Unload(bool hotReload)
        {
            this.ServiceManager.ShutdownServices(hotReload);
        }
    }
}
