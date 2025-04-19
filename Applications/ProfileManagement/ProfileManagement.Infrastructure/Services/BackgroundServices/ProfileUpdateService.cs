using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProfileManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class ParameterUpdateService : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<ParameterUpdateService> _logger;

    public ParameterUpdateService(IServiceScopeFactory serviceScopeFactory, ILogger<ParameterUpdateService> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("ParameterUpdateService started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var profileService = scope.ServiceProvider.GetRequiredService<IProfileService>();

                    var profiles = await profileService.GetAllProfilesAsync();

                    foreach (var profile in profiles)
                    {
                        var updatedParameters = profile.Parameters.ToDictionary(
                            param => param.Key,
                            param => param.Value == "true" ? "false" : "true"
                        );

                        await profileService.UpdateProfileAsync(profile.ProfileName, updatedParameters);
                        _logger.LogInformation($"Updated parameters for profile: {profile.ProfileName}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating profile parameters.");
            }

            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
        }

        _logger.LogInformation("ParameterUpdateService stopped.");
    }
}