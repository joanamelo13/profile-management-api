using MediatR;

namespace ProfileManagement.Application.Commands.Authenticate;

public record AuthenticateCommand(string Username, string Password) : IRequest<string?>;
