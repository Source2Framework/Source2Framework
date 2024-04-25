namespace Source2Framework.Models
{
    using CounterStrikeSharp.API.Core;

    /// <summary>
    /// Component for a managed 'OnTick' listener.
    /// </summary>
    public sealed class TickComponent : IComponent, IDisposable
    {
        private BasePlugin BasePlugin { get; set; }

        private Listeners.OnTick OnTick { get; set; }

        public TickComponent(BasePlugin plugin, Listeners.OnTick listener)
        {
            (this.BasePlugin = plugin).RegisterListener<Listeners.OnTick>((this.OnTick = listener));
        }

        public void Dispose()
        {
            this.BasePlugin.RemoveListener<Listeners.OnTick>(this.OnTick);
        }
    }
}
