namespace Source2Framework.Models
{
    public interface IServiceManager
    {
        public delegate void ServiceEvent(IService service, bool hotReload);

        public delegate void ServiceEvent<T>(IService service, T param);

        public List<IService> ServiceCollection { get; set; }

        public event ServiceEvent? OnServiceInitialized;

        public event ServiceEvent? OnServiceShutdown;

        public event ServiceEvent<Exception>? OnServiceException;

        public void RegisterService<TService>(IService service, bool hotReload = false)
            where TService : class, IService;

        public void RegisterServices(params IService[] services);

        public void RemoveService<TService>(bool hotReload = false)
            where TService : class, IService;

        public void RemoveService<TService>(IService service, bool hotReload = false)
            where TService : class, IService;

        public void RemoveServices(bool hotReload = false, params IService[] services);

        public TService? GetService<TService>()
            where TService : class, IService;

        public TService? GetService<TService>(string serviceTypeName)
            where TService : class, IService;

        public bool IsServiceAvailable<TService>()
            where TService : class, IService;

        public bool IsServiceAvailable(string serviceTypeName);

        public void ForEachService(Action<IService> callback);
    }
}
