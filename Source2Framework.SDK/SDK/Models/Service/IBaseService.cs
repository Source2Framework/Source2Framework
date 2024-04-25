namespace Source2Framework.Models
{
    public interface IBaseService<T> : IService
        where T : class, IService
    {
        public void Initialize(bool hotReload);

        public void Shutdown(bool hotReload);
    }
}
