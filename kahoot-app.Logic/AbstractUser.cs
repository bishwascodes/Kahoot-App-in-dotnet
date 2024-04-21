namespace kahoot_app.Logic;

// REQ#2.1.1
public abstract class AbstractUser
{
    protected static int IdCounter = 0;

    public int UserId { get; protected set; }
    public string Name { get; protected set; }

    protected AbstractUser(string name)
    {
        Name = name;
        IdCounter++;
        UserId = IdCounter;
    }
}
