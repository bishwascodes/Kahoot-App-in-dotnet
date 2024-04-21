namespace kahoot_app.Logic;
// REQ#2.1.2
public class Player : AbstractUser
{
    public Score? Score { get; set; }

    public new int PlayerId => UserId;
    public new string PlayerName => Name;

    public Player(string name) : base(name)
    {
        Score = new Score(name);
    }
}
