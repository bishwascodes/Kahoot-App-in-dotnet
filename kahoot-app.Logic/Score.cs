using kahoot_app.Logic;

public class Score
{
    public Score(string name)
    {
        PlayerName = name;
    }
    public int Id { get; }
    public string PlayerName { get;  }
    public int ScoreValue { get; set; }
    public DateTime Timestamp { get; set; }
}