namespace Source2Framework.Extensions
{
    using CounterStrikeSharp.API.Modules.Entities.Constants;

    public static partial class ItemDefinitionEx
    {
        public static bool IsKnife(this ItemDefinition itemDefinition)
        {
            switch (itemDefinition)
            {
                case ItemDefinition.KARAMBIT:
                case ItemDefinition.M9_BAYONET:
                case ItemDefinition.BAYONET:
                case ItemDefinition.SURVIVAL_KNIFE:
                case ItemDefinition.BOWIE_KNIFE:
                case ItemDefinition.BUTTERFLY_KNIFE:
                case ItemDefinition.FLIP_KNIFE:
                case ItemDefinition.URSUS_KNIFE:
                case ItemDefinition.TALON_KNIFE:
                case ItemDefinition.STILETTO_KNIFE:
                case ItemDefinition.SKELETON_KNIFE:
                case ItemDefinition.PARACORD_KNIFE:
                case ItemDefinition.NOMAD_KNIFE:
                case ItemDefinition.NAVAJA_KNIFE:
                case ItemDefinition.HUNTSMAN_KNIFE:
                case ItemDefinition.GUT_KNIFE:
                case ItemDefinition.FALCHION_KNIFE:
                case ItemDefinition.CLASSIC_KNIFE:
                case ItemDefinition.SHADOW_DAGGERS:
                case ItemDefinition.KNIFE_GHOST:
                case ItemDefinition.KNIFE_GG:
                case ItemDefinition.KNIFE_CT:
                case ItemDefinition.KNIFE_T:
                    return true;

                default: return false;
            }
        }

        public static bool IsGlove(this ItemDefinition itemDefinition)
        {
            switch (itemDefinition)
            {
                case ItemDefinition.BLOODHOUND_GLOVES:
                case ItemDefinition.BROKEN_FANG_GLOVES:
                case ItemDefinition.DEFAULT_CT_GLOVES:
                case ItemDefinition.DEFAULT_T_GLOVES:
                case ItemDefinition.DRIVER_GLOVES:
                case ItemDefinition.HYDRA_GLOVES:
                case ItemDefinition.MOTO_GLOVES:
                case ItemDefinition.SPECIALIST_GLOVES:
                case ItemDefinition.SPORT_GLOVES:
                    return true;

                default: return false;
            }
        }

        public static bool IsDefaultKnife(this ItemDefinition itemDefinition)
        {
            switch (itemDefinition)
            {
                case ItemDefinition.KNIFE_GG:
                case ItemDefinition.KNIFE_CT:
                case ItemDefinition.KNIFE_T:
                case ItemDefinition.KNIFE_GHOST:
                case ItemDefinition.BARE_HANDS:
                case ItemDefinition.MEELE:
                    return true;

                default: return false;
            }
        }

        public static bool IsGrenade(this ItemDefinition itemDefinition)
        {
            switch (itemDefinition)
            {
                case ItemDefinition.HIGH_EXPLOSIVE_GRENADE:
                case ItemDefinition.FLASHBANG:
                case ItemDefinition.SMOKE_GRENADE:
                case ItemDefinition.DECOY_GRENADE:
                case ItemDefinition.INCENDIARY_GRENADE:
                case ItemDefinition.MOLOTOV:
                case ItemDefinition.TACTICAL_AWARENESS_GRENADE:
                    return true;

                default: return false;
            }
        }

        public static bool IsC4(this ItemDefinition itemDefinition)
        {
            return itemDefinition == ItemDefinition.C4_EXPLOSIVE;
        }
    }
}
