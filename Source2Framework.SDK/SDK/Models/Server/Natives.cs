namespace Source2Framework
{
    using CounterStrikeSharp.API;

    public static partial class SDK
    {
        public static void RunOnTick(int tick, Action callback)
        {
            Server.RunOnTick(Server.TickCount + tick, callback);
        }

        public static async Task RunOnTickAsync(int tick, Action callback)
        {
            await Server.RunOnTickAsync(Server.TickCount + tick, callback);
        }
    }
}
