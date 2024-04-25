namespace Source2Framework.Models
{
    using CounterStrikeSharp.API.Core;

    public interface IS2FModule : IPlugin
    {
        public IFramework Framework { get; }

        public void OnCoreReady(IFramework framework, bool hotReload);
    }
}
