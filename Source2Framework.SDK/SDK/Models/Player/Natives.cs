namespace Source2Framework
{
    using CounterStrikeSharp.API;
    using CounterStrikeSharp.API.Core;

    using Source2Framework.Extensions;

    public static partial class SDK
    {
        public static void CPrintToChatAll(string message, Func<CCSPlayerController, bool>? predicate = null)
        {
            List<CCSPlayerController> players = Utilities.GetPlayers()
                .Where(player => player.IsValid() && (predicate == null || predicate(player)))
                .ToList();

            foreach (CCSPlayerController player in players)
            {
                player.CPrintToChat(message);
            }
        }
    }
}
