namespace Source2Framework.Models
{
    public interface IService
    {
        public void InitializeInternal(IServiceManager framework, bool hotReload);

        public void ShutdownInternal(bool hotReload);

        public void OnServicesInitialized(bool hotReload);

        public void OnServiceInitialized(IService service);

        public void OnServiceShutdown(IService service);

        public void OnServiceException(IService service, Exception exception);

        public string GetName()
        {
            return this.GetType().Name;
        }
    }
}
