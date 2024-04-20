using kahoot_app.Logic;

public class Score
{
    public Score(string name)
    {
        PlayerName = name;
        Value = 0;
        Rank = 1;
    }
    public int Id { get; }
    public string PlayerName { get; }

    public int Rank { get; set; }
    public int Value { get; set; }
    public DateTime Timestamp { get; set; }
    public void ChangeScore(int value)
    {
        Value = Value + value;
    }
}