using MediatR;
using ProfileManagement.Domain.Entities;

namespace ProfileManagement.Application.Profiles.Queries;

public record GetAllProfilesQuery : IRequest<IEnumerable<ProfileParameter>>;
