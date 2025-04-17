using MediatR;
using ProfileManagement.Domain.Entities;

namespace ProfileManagement.Application.Queries.GetProfileAsync;

public record GetProfileAsyncQuery : IRequest<IEnumerable<ProfileParameter>>;

