using kahoot_app.Logic;

public class Score
{
    public Score(string name)
    {
        PlayerName = name;
        Value = 0;
    }
   
    public string PlayerName { get; }

    public int Value { get; set; }
     public void ChangeScore(int value)
    {
        Value = Value + value;
    }
}