namespace Source2Framework.Models
{
    public static class IComponentHolderImpl
    {
        public static bool AddComponent<TComponent>(this IComponentHolder holder, TComponent component)
            where TComponent : IComponent
        {
            holder.Components.Add(component);
            return true;
        }

        public static bool AddComponents(this IComponentHolder holder, params IComponent[] components)
        {
            foreach (IComponent component in components)
            {
                holder.Components.Add(component);
            }

            return true;
        }

        public static TComponent? CreateComponent<TComponent>(this IComponentHolder holder)
            where TComponent : IComponent, IDisposable, new()
        {
            TComponent? component = (TComponent?)Activator.CreateInstance(typeof(TComponent));

            if (component != null)
            {
                holder.AddComponent<TComponent>(component);
            }

            return component;
        }

        public static TComponent? CreateComponent<TComponent>(this IComponentHolder holder, params object?[] args)
            where TComponent : IComponent, IDisposable
        {
            TComponent? component = (TComponent?)Activator.CreateInstance(typeof(TComponent), args);

            if (component != null)
            {
                holder.AddComponent<TComponent>(component);
            }

            return component;
        }

        public static bool DestroyComponent<TComponent>(this IComponentHolder holder)
            where TComponent : IComponent, IDisposable
        {
            IEnumerable<TComponent> components = holder.Components.OfType<TComponent>();
            bool result = true;

            foreach (IComponent component in components)
            {
                if (component is IDisposable)
                {
                    ((IDisposable)component).Dispose();
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

        public static IComponent? GetComponent<TComponent>(this IComponentHolder holder)
            where TComponent : IComponent
        {
            return holder.Components.OfType<TComponent>().FirstOrDefault();
        }

        public static IEnumerable<IComponent> GetComponents(this IComponentHolder holder)
        {
            return holder.Components;
        }

        public static IEnumerable<IComponent> GetComponents(this IComponentHolder holder, Func<IComponent, bool> predicate)
        {
            return holder.Components.Where(predicate);
        }

        public static bool RemoveComponent<TComponent>(this IComponentHolder holder)
            where TComponent : IComponent
        {
            IComponent? component = holder.GetComponent<TComponent>();

            if (component != null)
            {
                return holder.Components.Remove(component);
            }

            return false;
        }

        public static bool RemoveComponents(this IComponentHolder holder, params IComponent[] components)
        {
            return holder.Components.RemoveAll((component) => components.Any(c => c == component)) > 0;
        }
    }
}
