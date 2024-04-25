namespace Source2Framework.Models
{
    using CounterStrikeSharp.API.Core;

    /// <summary>
    /// Can be used to cache an entity and automatically update it when it becomes invalid.
    /// </summary>
    /// <typeparam name="T">The entity type</typeparam>
    public class EntityCache<T> where T : CEntityInstance
    {
        private readonly Func<T?> ValueFactory;

        private Lazy<T?> LazyValue;

        public EntityCache(Func<T> valueFactory)
        {
            this.ValueFactory = valueFactory;
            this.LazyValue = new Lazy<T?>(this.ValueFactory);
        }

        public bool IsValid => this.LazyValue.Value != null && this.LazyValue.Value.IsValid;

        public T? Value
        {
            get
            {
                if (!this.IsValid)
                {
                    this.LazyValue = new Lazy<T?>(() => this.ValueFactory());
                }

                return this.LazyValue.Value;
            }
        }
    }
}
