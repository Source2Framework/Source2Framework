namespace Source2Framework.Models
{
    using CounterStrikeSharp.API;
    using CounterStrikeSharp.API.Core;

    public unsafe class INetworkGameServer : NativeObject
    {
        private static int SlotsOffset = GameData.GetOffset("INetworkGameServer_Slots");

        private static int DeltaTickOffset = GameData.GetOffset("INetworkGameServer_DeltaTick");

        private nint** Slots;

        public INetworkGameServer(nint ptr) : base(ptr)
        {
            this.Slots = *(nint***)(this.Handle + SlotsOffset);
        }

        public void ForceFullUpdate(CCSPlayerController player)
        {
            this.SetDeltaTick(player.Slot, -1);
        }

        public void ForceFullUpdate(int playerSlot)
        {
            this.SetDeltaTick(playerSlot, -1);
        }

        public int GetDeltaTick(CCSPlayerController player)
        {
            return this.GetDeltaTick(player.Slot);
        }

        public void SetDeltaTick(CCSPlayerController player, int deltaTick)
        {
            this.SetDeltaTick(player.Slot, deltaTick);
        }

        public unsafe int GetDeltaTick(int playerSlot)
        {
            return *(int*)((nint)this.Slots[playerSlot] + DeltaTickOffset);
        }

        public unsafe void SetDeltaTick(int playerSlot, int deltaTick)
        {
            *(int*)((nint)this.Slots[playerSlot] + DeltaTickOffset) = deltaTick;
        }
    }
}
