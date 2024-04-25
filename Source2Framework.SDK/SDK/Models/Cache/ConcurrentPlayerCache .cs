namespace Source2Framework.Models
{
    using System.Collections.Concurrent;
    using CounterStrikeSharp.API.Core;

    public class ConcurrentPlayerCache<T> : ConcurrentDictionary<int, T>, IPlayerCache<T>
    {
        public T this[CCSPlayerController controller]
        {
            get
            {
                if (base.TryGetValue(controller.Slot, out T? value))
                {
                    return value;
                }

                return default(T)!;
            }

            set { this[controller.Slot] = value; }
        }

        public bool ContainsPlayer(CCSPlayerController player)
        {
            return base.ContainsKey(player.Slot);
        }

        public bool ContainsPlayer(int playerSlot)
        {
            return base.ContainsKey(playerSlot);
        }

        public bool RemovePlayer(CCSPlayerController player)
        {
            return base.TryRemove(player.Slot, out T? _);
        }

        public bool RemovePlayer(int playerSlot)
        {
            return base.TryRemove(playerSlot, out T? _);
        }
    }
}
