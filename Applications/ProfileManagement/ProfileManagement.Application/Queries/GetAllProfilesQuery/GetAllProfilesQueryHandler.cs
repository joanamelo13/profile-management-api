using MediatR;
using ProfileManagement.Application.Interfaces;
using ProfileManagement.Domain.Entities;

namespace ProfileManagement.Application.Profiles.Queries;

public class GetAllProfilesQueryHandler : IRequestHandler<GetAllProfilesQuery, IEnumerable<ProfileParameter>>
{
    private readonly IProfileService _profileService;

    public GetAllProfilesQueryHandler(IProfileService profileService)
    {
        _profileService = profileService;
    }

    public async Task<IEnumerable<ProfileParameter>> Handle(GetAllProfilesQuery request, CancellationToken cancellationToken)
    {
        return await _profileService.GetAllProfilesAsync();
    }
}
