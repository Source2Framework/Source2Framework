namespace Source2Framework.Models
{
    public sealed class ProxyComponent<T> : IComponent
    {
        private T Proxy { get; set; }

        public ProxyComponent(T value)
        {
            this.Proxy = value;
        }

        public T GetValue()
        {
            return this.Proxy;
        }
    }
}
