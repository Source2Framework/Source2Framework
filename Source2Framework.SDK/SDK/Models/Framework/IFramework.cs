namespace Source2Framework.Models
{
    public interface IFramework
    {
        public bool IsInitialized { get; }

        public ServiceManager Services { get; }

        public INetworkServerService NetworkServerService { get; }

        public event Action<IFramework, bool>? OnCoreReady;

        public void RegisterService<TService>(IService service, bool hotReload = false)
            where TService : class, IService;

        public bool IsServiceAvailable<T>()
            where T : class, IService;

        public T? GetService<T>()
            where T : class, IService;
    }
}
