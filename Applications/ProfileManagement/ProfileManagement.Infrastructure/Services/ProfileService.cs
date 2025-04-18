using Microsoft.EntityFrameworkCore;
using ProfileManagement.Application.Interfaces;
using ProfileManagement.Domain.Entities;
using ProfileManagement.Infrastructure.Data;

namespace ProfileManagement.Infrastructure.Services;

public class ProfileService : IProfileService
{
    private readonly ApplicationDbContext _dbContext;

    public ProfileService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ProfileParameter>> GetAllProfilesAsync()
    {
        return await _dbContext.Profiles.ToListAsync();
    }

    public async Task<ProfileParameter?> GetProfileAsync(string profileName)
    {
        return await _dbContext.Profiles.FirstOrDefaultAsync(p => p.ProfileName == profileName);
    }

    public async Task AddProfileAsync(ProfileParameter profile)
    {
        _dbContext.Profiles.Add(profile);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateProfileAsync(string profileName, Dictionary<string, string> parameters)
    {
        var profile = await _dbContext.Profiles.FirstOrDefaultAsync(p => p.ProfileName == profileName);
        if (profile != null)
        {
            profile.Parameters = parameters;
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteProfileAsync(string profileName)
    {
        var profile = await _dbContext.Profiles.FirstOrDefaultAsync(p => p.ProfileName == profileName);
        if (profile != null)
        {
            _dbContext.Profiles.Remove(profile);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<bool> ValidateProfileAsync(string profileName, string action)
    {
        var profile = await _dbContext.Profiles.FindAsync(profileName);
        return profile != null && profile.Parameters.TryGetValue(action, out var value) && value == "true";
    }
}