using ProfileManagement.Application.Exceptions.Resources;

namespace ProfileManagement.Infrastructure.Configuration;

public class DefaultUsersConfig
{
    private UserConfig _admin = new();
    private UserConfig _user = new();

    public UserConfig Admin
    {
        get => _admin;
        set => _admin = value ?? throw new ArgumentNullException(nameof(value), ExceptionMsg.EXC0001);
    }

    public UserConfig User
    {
        get => _user;
        set => _user = value ?? throw new ArgumentNullException(nameof(value), ExceptionMsg.EXC0001);
    }

}
