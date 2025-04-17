using ProfileManagement.Domain.Entities;

namespace ProfileManagement.Application.Interfaces;

public interface IProfileService
{
    Task<IEnumerable<ProfileParameter>> GetAllProfilesAsync();
    Task<ProfileParameter?> GetProfileAsync(string profileName);
    Task AddProfileAsync(ProfileParameter profile);
    Task UpdateProfileAsync(string profileName, Dictionary<string, string> parameters);
    Task DeleteProfileAsync(string profileName);
    Task<bool> ValidateProfileAsync(string profileName, string action);
}