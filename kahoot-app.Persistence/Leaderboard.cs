namespace kahoot_app.Persistence;

public class Leaderboard
{
    public string Name { get; set; }
    public int Rank { get; set; }
    public int Score { get; set; }
    public static List<(int, string, int)> LeaderboardPlayers = new();

    public void UpdateLeaderboard(List<(string playerName, int rank, int score)> playerData)
    {
      
    }

}
