namespace Source2Framework.Models
{
    using CounterStrikeSharp.API.Core;

    public class PlayerCache<T> : Dictionary<int, T>, IPlayerCache<T>
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
            return base.Remove(player.Slot);
        }

        public bool RemovePlayer(int playerSlot)
        {
            return base.Remove(playerSlot);
        }
    }
}
