using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfileManagement.Application.Interfaces;
using ProfileManagement.Domain.Entities;

namespace ProfileManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProfilesController : ControllerBase
{
    private readonly IProfileService _profileService;

    public ProfilesController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllProfiles()
    {
        var profiles = await _profileService.GetAllProfilesAsync();
        return Ok(profiles);
    }

    [HttpGet("{profileName}")]
    [Authorize]
    public async Task<IActionResult> GetProfile(string profileName)
    {
        var profile = await _profileService.GetProfileAsync(profileName);
        if (profile == null) return NotFound();
        return Ok(profile);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddProfile(ProfileParameter profile)
    {
        await _profileService.AddProfileAsync(profile);
        return CreatedAtAction(nameof(GetProfile), new { profileName = profile.ProfileName }, profile);
    }

    [HttpPut("{profileName}")]
    [Authorize]
    public async Task<IActionResult> UpdateProfile(string profileName, Dictionary<string, string> parameters)
    {
        await _profileService.UpdateProfileAsync(profileName, parameters);
        return NoContent();
    }

    [HttpDelete("{profileName}")]
    [Authorize]
    public async Task<IActionResult> DeleteProfile(string profileName)
    {
        await _profileService.DeleteProfileAsync(profileName);
        return NoContent();
    }

    [HttpGet("{profileName}/validate")]
    [Authorize]
    public async Task<IActionResult> ValidateProfile(string profileName, [FromQuery] string action)
    {
        var isValid = await _profileService.ValidateProfileAsync(profileName, action);
        return Ok(isValid);
    }
}