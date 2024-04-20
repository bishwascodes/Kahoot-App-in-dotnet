namespace kahoot_app.Logic;

public class Admin
{
    public static int adminId = 0;
    private static List<Admin> adminInstances = new List<Admin>(); // Static list to hold all Admin instances
    public Admin(string adminName)
    {
        _name = adminName;
        adminInstances.Add(this); // Add current instance to the list upon creation
        adminId++;
        AdminId = adminId;
    }
    public int AdminId{
        get;
    }
    private string _name;
    
    public string Name
    {
        get
        {
            return _name;
        }
    }

    // Static property to access the list of all Admin instances
    public static List<Admin> AdminInstances
    {
        get { return adminInstances; }
    }
}