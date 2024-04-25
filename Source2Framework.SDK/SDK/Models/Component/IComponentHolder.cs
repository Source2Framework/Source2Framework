namespace Source2Framework.Models
{
    /// <summary>
    /// This is "implemented" with extension methods so we can still inherit from other classes while being a IComponentHolder
    /// </summary>
    public interface IComponentHolder
    {
        public List<IComponent> Components { get; }
    }
}
