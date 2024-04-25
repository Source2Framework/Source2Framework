namespace Source2Framework.Models
{
    using CounterStrikeSharp.API.Core;

    /// <summary>
    /// <para>Component for saving a 'BasePlugin' instance.</para>
    /// <para>Useful in contexts where you cannot get the plugin instance directly.</para>
    /// <para> Note: Getting instance for this component using <see cref="ComponentHolder.GetComponent{PluginComponent}"/> can be implicitly casted to <see cref="BasePlugin"/></para>
    /// <para> ^ This could be useful, especially if you dont need your plugin type explicitly.</para>
    /// </summary>
    public sealed class PluginComponent : IComponent
    {
        private BasePlugin Plugin { get; set; }

        public PluginComponent(BasePlugin plugin)
        {
            this.Plugin = plugin;
        }

        public TPluginType GetPlugin<TPluginType>()
            where TPluginType : BasePlugin
        {
            return (TPluginType)this.Plugin;
        }

        public static implicit operator BasePlugin(PluginComponent component) => component.Plugin;
    }
}
