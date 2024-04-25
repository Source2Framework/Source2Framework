namespace Source2Framework.Extensions
{
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Modules.Entities.Constants;

    public static partial class CBasePlayerWeaponEx
    {
        public static ItemDefinition GetItemDefinition(this CBasePlayerWeapon weapon)
        {
            return (ItemDefinition)weapon.AttributeManager.Item.ItemDefinitionIndex;
        }

        public static bool IsKnife(this CBasePlayerWeapon weapon)
        {
            return weapon.GetItemDefinition().IsKnife();
        }

        public static bool IsC4(this CBasePlayerWeapon weapon)
        {
            return weapon.GetItemDefinition().IsC4();
        }

        public static bool IsGrenade(this CBasePlayerWeapon weapon)
        {
            return weapon.GetItemDefinition().IsGrenade();
        }

        public static bool IsDefaultKnife(this CBasePlayerWeapon weapon)
        {
            return weapon.GetItemDefinition().IsDefaultKnife();
        }
    }
}
