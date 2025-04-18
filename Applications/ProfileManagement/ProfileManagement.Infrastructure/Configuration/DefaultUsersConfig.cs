namespace ProfileManagement.Infrastructure.Configuration;

public class DefaultUsersConfig
{
    #region Constants
    const string adminUsername = "admin";
    const string adminPassword = "KyfH9i#K";
    const string adminRole = "Admin";

    const string userUsername = "user";
    const string userPassword = "Bgj9H@16";
    const string userRole = "User";
    #endregion

    private UserConfig _admin = new();
    private UserConfig _user = new();

    public UserConfig Admin
    {
        get => _admin;
        set => _admin = value ?? new () { Username = adminUsername, Password = adminPassword, Role = adminRole };
    }

    public UserConfig User
    {
        get => _user;
        set => _user = value ?? new() { Username = userUsername, Password = userPassword, Role = userRole };
    }
}
