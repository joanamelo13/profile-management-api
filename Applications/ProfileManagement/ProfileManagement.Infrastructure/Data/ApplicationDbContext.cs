using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProfileManagement.Application.Exceptions.Resources;
using ProfileManagement.Domain.Entities;
using ProfileManagement.Infrastructure.Configuration;


namespace ProfileManagement.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    private readonly DefaultUsersConfig _defaultUsersConfig;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options) 
        => _defaultUsersConfig = _defaultUsersConfig = configuration.GetSection("DefaultUsers").Get<DefaultUsersConfig>()
        ?? throw new InvalidOperationException(ExceptionMsg.EXC0000);

    public DbSet<ProfileParameter> Profiles { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProfileParameter>().HasKey(p => p.ProfileName);
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData(
            new ()
            {
                Username = _defaultUsersConfig.Admin.Username,
                Password = _defaultUsersConfig.Admin.Password,
                Role = _defaultUsersConfig.Admin.Role
            },
            new ()
            {
                Username = _defaultUsersConfig.User.Username,
                Password = _defaultUsersConfig.User.Password,
                Role = _defaultUsersConfig.User.Role
            }
        );
    }
}