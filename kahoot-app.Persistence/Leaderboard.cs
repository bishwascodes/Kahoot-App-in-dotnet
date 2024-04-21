namespace kahoot_app.Persistence;
using System.Text.Json;

//REQ#2.3.1
//REQ#1.8.3 
public static class Leaderboard
{
    private const string FilePath = "../kahoot-app.Persistence/LeaderboardPlayers.json";

    // Initialize the LeaderboardPlayers list with data from the file when the class is loaded
    public static List<(int, string, int)> LeaderboardPlayers { get; private set; } = LoadLeaderboard();

    public static void UpdateLeaderboard(List<(string playerName, int rank, int score)> playerData)
    {
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

        // Save the leaderboard to file
        SaveLeaderboard();
    }
    public static void UpdateLeaderboard(List<( int rank,string playerName, int score)> playerData)
    {
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

        // Save the leaderboard to file
        SaveLeaderboard();
    }

    private static void SaveLeaderboard()
    {
        List<LeaderboardData> data = new();
        var temp = LeaderboardPlayers;
        foreach (var item in temp)
        {
            data.Add(new LeaderboardData()
            {
                Rank = item.Item1,
                Name = item.Item2,
                Score = item.Item3,
            });
        }
        string json = JsonSerializer.Serialize(data);
        File.WriteAllText(FilePath, json);
    }

    private static List<(int, string, int)> LoadLeaderboard()
    {
        if (File.Exists(FilePath))
        {
            List<(int, string, int)> tupleList = new List<(int, string, int)>();
            string json = File.ReadAllText(FilePath);
            var temp = JsonSerializer.Deserialize<List<LeaderboardData>>(json);
            foreach (var item in temp)
            {
                tupleList.Add((item.Rank, item.Name, item.Score));
            }
            return tupleList;

        }
        else
        {
            // If the file does not exist, return an empty list
            return new List<(int, string, int)>();
        }
    }
}

public class LeaderboardData
{
    public int Rank { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
}