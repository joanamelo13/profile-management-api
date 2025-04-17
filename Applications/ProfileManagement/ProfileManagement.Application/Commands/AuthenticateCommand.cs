using MediatR;

namespace ProfileManagement.Application.Auth.Commands;

public record AuthenticateCommand(string Username, string Password) : IRequest<string?>;
