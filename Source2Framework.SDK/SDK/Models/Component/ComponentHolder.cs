namespace Source2Framework.Models
{
    public abstract class ComponentHolder : IComponentHolderBase
    {
        private List<IComponent> Components { get; } = new List<IComponent>();

        public bool AddComponent<TComponent>(TComponent component)
            where TComponent : IComponent
        {
            this.Components.Add(component);
            return true;
        }

        public bool AddComponents(params IComponent[] components)
        {
            foreach (IComponent component in components)
            {
                this.Components.Add(component);
            }

            return true;
        }

        public TComponent? CreateComponent<TComponent>()
            where TComponent : IComponent, IDisposable, new()
        {
            TComponent? component = (TComponent?)Activator.CreateInstance(typeof(TComponent));
            
            if (component != null)
            {
                this.AddComponent<TComponent>(component);
            }

            return component;
        }

        public TComponent? CreateComponent<TComponent>(params object?[] args)
            where TComponent : IComponent, IDisposable
        {
            TComponent? component = (TComponent?)Activator.CreateInstance(typeof(TComponent), args);

            if (component != null)
            {
                this.AddComponent<TComponent>(component);
            }

            return component;
        }

        public bool DestroyComponent<TComponent>()
            where TComponent : IComponent, IDisposable
        {
            IEnumerable<TComponent> components = this.Components.OfType<TComponent>();
            bool result = true;

            foreach (IComponent component in components)
            {
                if (component is IDisposable)
                {
                    ((IDisposable)component).Dispose();
                } else
                {
                    result = false;
                }
            }

            return result;
        }

        public IComponent? GetComponent<TComponent>()
            where TComponent : IComponent
        {
            return this.Components.OfType<TComponent>().FirstOrDefault();
        }

        public IEnumerable<IComponent> GetComponents()
        {
            return this.Components;
        }

        public IEnumerable<IComponent> GetComponents(Func<IComponent, bool> predicate)
        {
            return this.Components.Where(predicate);
        }

        public bool RemoveComponent<TComponent>()
            where TComponent : IComponent
        {
            IComponent? component = this.GetComponent<TComponent>();

            if (component != null)
            {
                return this.Components.Remove(component);
            }

            return false;
        }

        public bool RemoveComponents(params IComponent[] components)
        {
            return this.Components.RemoveAll((IComponent component) => components.Any((IComponent c) => c == component)) > 0;
        }
    }
}
