using MediatR;
using ProfileManagement.Application.Interfaces;

namespace ProfileManagement.Application.Commands.Authenticate;

public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, string?>
{
    private readonly IAuthenticateCommandHandler _authenticateCommandHandler;

    public AuthenticateCommandHandler(IAuthenticateCommandHandler authenticateCommandHandler)
    {
        _authenticateCommandHandler = authenticateCommandHandler;
    }

    public async Task<string?> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
        return await _authenticateCommandHandler.AuthenticateAsync(request.Username, request.Password);
    }
}
