namespace Source2Framework.Models
{
    public class ServiceManager : IServiceManager
    {
        public List<IService> ServiceCollection { get; set; } = new List<IService>();

        public event IServiceManager.ServiceEvent? OnServiceInitialized;

        public event IServiceManager.ServiceEvent? OnServiceShutdown;

        public event IServiceManager.ServiceEvent<Exception>? OnServiceException;

        public void RegisterService<TService>(IService service, bool hotReload = false)
            where TService : class, IService
        {
            if (this.IsServiceAvailable<TService>())
            {
                throw new Exception($"A service with type '{service.GetName()}' is already registered");
            }

            if (hotReload)
            {
                service.InitializeInternal(this, hotReload);
            }

            this.ServiceCollection.Add(service);
        }

        public void RegisterServices(params IService[] services)
        {
            foreach (IService service in services)
            {
                this.RegisterService<IService>(service);
            }
        }

        public void RemoveService<TService>(bool hotReload = false)
            where TService : class, IService
        {
            TService? service = this.GetService<TService>();

            if (service != null)
            {
                service.ShutdownInternal(hotReload);
                this.ServiceCollection.Remove(service);
            }
        }

        public void RemoveService<TService>(IService service, bool hotReload = false)
            where TService : class, IService
        {
            if (!this.IsServiceAvailable<TService>())
            {
                throw new Exception($"Service '{service.GetName()}' does not exists");
            }

            service.ShutdownInternal(hotReload);
            this.ServiceCollection.Remove(service);
        }

        public void RemoveServices(bool hotReload = false, params IService[] services)
        {
            IEnumerable<IService> collection = this.ServiceCollection.Where((service) => services.Any((inService) => service.GetType() == inService.GetType()));

            foreach (IService service in collection)
            {
                this.RemoveService<IService>(service, hotReload);
            }
        }

        public TService? GetService<TService>()
            where TService : class, IService
        {
            return (TService?)this.ServiceCollection.FirstOrDefault(s => s.GetType() == typeof(TService) ||
                    (s.GetType().IsAssignableTo(typeof(TService)) && s.GetType().IsAssignableTo(typeof(ISharedService))));
        }

        public TService? GetService<TService>(string serviceTypeName)
            where TService : class, IService
        {
            return (TService?)this.ServiceCollection.FirstOrDefault(s => s.GetName() == serviceTypeName);
        }

        public bool IsServiceAvailable<TService>()
            where TService : class, IService
        {
            return this.ServiceCollection.Any(s => s.GetType() == typeof(TService) ||
                    (s.GetType().IsAssignableTo(typeof(TService)) && s.GetType().IsAssignableTo(typeof(ISharedService))));
        }

        public bool IsServiceAvailable(string serviceTypeName)
        {
            return this.ServiceCollection.Any(s => s.GetName() == serviceTypeName);
        }

        public void ForEachService(Action<IService> callback)
        {
            this.ServiceCollection.ForEach(callback);
        }

        public void OnServiceInitializedInternal(IService service, bool hotReload)
        {
            this.ForEachService((inService) => inService.OnServiceInitialized(service));
            this.OnServiceInitialized?.Invoke(service, hotReload);
        }

        public void OnServiceShutdownInternal(IService service, bool hotReload)
        {
            this.ForEachService((inService) => inService.OnServiceShutdown(service));
            this.OnServiceShutdown?.Invoke(service, hotReload);
        }

        public void OnServiceExceptionInternal(IService service, Exception exception)
        {
            this.ForEachService(service => service.OnServiceException(service, exception));
            this.OnServiceException?.Invoke(service, exception);
        }

        public void InitializeServices(bool hotReload)
        {
            this.ForEachService(service => service.InitializeInternal(this, hotReload));
        }

        public void ShutdownServices(bool hotReload)
        {
            this.ForEachService(service => service.ShutdownInternal(hotReload));
        }
    }
}
