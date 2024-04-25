namespace Source2Framework.Extensions
{
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Modules.Entities.Constants;
    using CounterStrikeSharp.API.Modules.Utils;

    public static partial class CCSPlayerControllerEx
    {
        public static CBasePlayerWeapon? GetWeapon(this CCSPlayerController controller, Func<CBasePlayerWeapon, bool> predicate)
        {
            NetworkedVector<CHandle<CBasePlayerWeapon>> weapons = controller.GetWeapons();

            foreach (CHandle<CBasePlayerWeapon> currentWeapon in weapons)
            {
                if (currentWeapon.Value == null || !currentWeapon.IsValid || !currentWeapon.Value.IsValid)
                    continue;

                if (predicate(currentWeapon.Value))
                {
                    return currentWeapon.Value;
                }
            }

            return null;
        }

        public static CBasePlayerWeapon? GetWeapon(this CCSPlayerController controller, ItemDefinition itemDefinition)
        {
            NetworkedVector<CHandle<CBasePlayerWeapon>> weapons = controller.GetWeapons();

            foreach (CHandle<CBasePlayerWeapon> currentWeapon in weapons)
            {
                if (currentWeapon.Value == null || !currentWeapon.IsValid || !currentWeapon.Value.IsValid)
                    continue;

                if (currentWeapon.Value.GetItemDefinition() == itemDefinition)
                {
                    return currentWeapon.Value;
                }
            }

            return null;
        }

        public static CBasePlayerWeapon? GetEquippedKnife(this CCSPlayerController controller)
        {
            return controller.GetWeapon((weapon) => { return weapon.IsKnife(); });
        }

        public static NetworkedVector<CHandle<CBasePlayerWeapon>> GetWeapons(this CCSPlayerController controller)
        {
            return controller.Pawn.Value!.WeaponServices!.MyWeapons;
        }

        public static bool IsValid(this CCSPlayerController? player, bool excludeBots = true)
        {
            if (player == null || !player.IsValid || player.UserId == null || !player.UserId.HasValue || player.UserId.Value < 0)
                return false;

            if (!excludeBots && player.IsBot)
                return false;

            return true;
        }

        public static bool IsPawnValid(this CCSPlayerController player)
        {
            return player.PlayerPawn != null && player.PlayerPawn.Value != null && player.PlayerPawn.IsValid;
        }

        public static void CPrintToChat(this CCSPlayerController player, string message)
        {
            player.PrintToChat($" {message}".ReplaceColorTags());
        }
    }
}
