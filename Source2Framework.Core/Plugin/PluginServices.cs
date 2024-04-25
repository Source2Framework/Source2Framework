namespace Source2Framework
{
    using CounterStrikeSharp.API.Core;

    using Source2Framework.Services.Framework;
    using Source2Framework.Models;

    public class PluginServices : IPluginServiceCollection<Plugin>
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            // this might get located somewhere else in the future (either a service with exposing game internals, or just a different file)
            serviceCollection.AddSingleton<INetworkServerService>();

            serviceCollection.AddSingleton<ServiceManager>();
            serviceCollection.AddSingleton<FrameworkService>();
        }
    }
}
