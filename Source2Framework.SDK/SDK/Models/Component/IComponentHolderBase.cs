namespace Source2Framework.Models
{
    public interface IComponentHolderBase
    {
        public TComponent? CreateComponent<TComponent>()
            where TComponent : IComponent, IDisposable, new();

        public TComponent? CreateComponent<TComponent>(params object?[] args)
            where TComponent : IComponent, IDisposable;

        public bool DestroyComponent<TComponent>()
            where TComponent : IComponent, IDisposable;

        public bool AddComponent<TComponent>(TComponent component)
            where TComponent : IComponent;

        public bool AddComponents(params IComponent[] components);

        public bool RemoveComponent<TComponent>()
            where TComponent : IComponent;

        public bool RemoveComponents(params IComponent[] components);

        public IComponent? GetComponent<TComponent>()
            where TComponent : IComponent;

        public IEnumerable<IComponent> GetComponents();

        public IEnumerable<IComponent> GetComponents(Func<IComponent, bool> predicate);
    }
}
