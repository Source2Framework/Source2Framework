namespace Source2Framework
{
    using CounterStrikeSharp.API;
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Modules.Utils;

    public static partial class SDK
    {
        public static CCSPlayerResource GetPlayerResource()
        {
            return Utilities.FindAllEntitiesByDesignerName<CCSPlayerResource>(Constants.Entities.PlayerManager).First();
        }

        public static CCSGameRules GetGameRules()
        {
            return Utilities.FindAllEntitiesByDesignerName<CCSGameRulesProxy>(Constants.Entities.GameRules).First().GameRules!;
        }

        public static IEnumerable<CCSTeam> GetTeamManagers()
        {
            return Utilities.FindAllEntitiesByDesignerName<CCSTeam>(Constants.Entities.TeamManager);
        }

        public static CCSTeam? GetTeamManager(CsTeam team)
        {
            IEnumerable<CCSTeam> teamManagers = SDK.GetTeamManagers();

            foreach (CCSTeam teamManager in teamManagers)
            {
                if (teamManager.TeamNum == (int)team)
                    return teamManager;
            }

            return null;
        }
    }
}
