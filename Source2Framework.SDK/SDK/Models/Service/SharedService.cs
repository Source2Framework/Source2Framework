namespace Source2Framework.Models
{
    using CounterStrikeSharp.API.Core.Plugin;

    public abstract class SharedService<T> : BaseService<T>
        where T : class, ISharedService
    {
        public SharedService(ILogger<T> logger, IPluginContext pluginContext) : base(logger, pluginContext)
            { }
    }
}
