namespace kahoot_app.Logic;
// REQ#2.1.2
public class Admin : AbstractUser
{
    private static List<Admin> adminInstances = new List<Admin>();

    public static List<Admin> AdminInstances => adminInstances;

    public new int AdminId => UserId;
    public new string AdminName => Name;

    public Admin(string name) : base(name)
    {
        adminInstances.Add(this);
    }
}