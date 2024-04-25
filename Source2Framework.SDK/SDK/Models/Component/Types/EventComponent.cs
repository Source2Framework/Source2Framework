namespace Source2Framework.Models
{
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Modules.Events;

    using static CounterStrikeSharp.API.Core.BasePlugin;

    /// <summary>
    /// Component for a managed '<see cref="GameEventHandler{T}"/>' handler.
    /// </summary>
    public sealed class EventComponent<TEvent> : IComponent, IDisposable
        where TEvent : GameEvent
    {
        private BasePlugin BasePlugin { get; set; }

        private GameEventHandler<TEvent> EventHandler { get; set; }

        public EventComponent(BasePlugin plugin, GameEventHandler<TEvent> callback)
        {
            (this.BasePlugin = plugin).RegisterEventHandler<TEvent>((this.EventHandler = callback));
        }

        public void Dispose()
        {
            this.BasePlugin.DeregisterEventHandler<TEvent>(this.EventHandler);
        }
    }
}
