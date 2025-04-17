using MediatR;
using ProfileManagement.Application.Interfaces;

namespace ProfileManagement.Application.Auth.Commands;

public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, string?>
{
    private readonly IAuthService _authService;

    public AuthenticateCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<string?> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
        return await _authService.AuthenticateAsync(request.Username, request.Password);
    }
}
