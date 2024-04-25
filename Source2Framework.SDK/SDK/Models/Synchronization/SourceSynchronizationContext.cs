namespace Source2Framework.Models
{
    using CounterStrikeSharp.API;

    public class SourceSynchronizationContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback callback, object? state)
        {
            Server.NextWorldUpdate(() => callback(state));
        }

        public override SynchronizationContext CreateCopy()
        {
            return this;
        }
    }
}
