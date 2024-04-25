namespace Source2Framework.Models
{
    using CounterStrikeSharp.API.Core;

    public interface IPlayerCache<T> : IDictionary<int, T>
    {
        public T this[CCSPlayerController controller] { get; set; }

        public bool ContainsPlayer(CCSPlayerController player);

        public bool ContainsPlayer(int playerSlot);

        public bool RemovePlayer(CCSPlayerController player);

        public bool RemovePlayer(int playerSlot);
    }
}
