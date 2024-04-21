namespace kahoot_app.Persistence;

public class Leaderboard
{
    public string Name { get; set; }
    public int Rank { get; set; }
    public int Score { get; set; }
    public static List<(int, string, int)> LeaderboardPlayers = new();

    public void UpdateLeaderboard(List<(string playerName, int rank, int score)> playerData)
    {
        // Initialize LeaderboardPlayers if it's empty
        if (LeaderboardPlayers == null)
        {
            LeaderboardPlayers = new List<(int, string, int)>();
        }

        // Merge existing leaderboard data with the new player data
        foreach (var playerInfo in playerData)
        {
            var existingPlayerIndex = LeaderboardPlayers.FindIndex(p => p.Item2 == playerInfo.playerName);

            // If the player already exists in the leaderboard
            if (existingPlayerIndex != -1)
            {
                // If the new score is higher, update the existing player's score
                if (LeaderboardPlayers[existingPlayerIndex].Item3 < playerInfo.score)
                {
                    LeaderboardPlayers[existingPlayerIndex] = (playerInfo.rank, playerInfo.playerName, playerInfo.score);
                }
            }
            else // If the player doesn't exist, add them to the leaderboard
            {
                LeaderboardPlayers.Add((playerInfo.rank, playerInfo.playerName, playerInfo.score));
            }
        }

        // Sort the leaderboard by score in descending order
        LeaderboardPlayers = LeaderboardPlayers.OrderByDescending(p => p.Item3).ToList();

        // Keep only the top 10 players
        LeaderboardPlayers = LeaderboardPlayers.Take(10).ToList();

        // Update ranks based on the sorted order
        for (int i = 0; i < LeaderboardPlayers.Count; i++)
        {
            LeaderboardPlayers[i] = (i + 1, LeaderboardPlayers[i].Item2, LeaderboardPlayers[i].Item3);
        }
    }

}
