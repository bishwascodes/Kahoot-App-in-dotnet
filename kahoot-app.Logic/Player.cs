namespace kahoot_app.Logic;

public class Player
{
    private static int playerId = 0;
    public Score? Score;
    public Player(string name)
    {
        _name = name;
        playerId++;
        PlayerId = playerId;
        Score = new Score(Name);
    }
    
    public int PlayerId{
        get;
    }
    private string _name;

    public string Name{
        get{
            return _name;
        }
    }
    

}
