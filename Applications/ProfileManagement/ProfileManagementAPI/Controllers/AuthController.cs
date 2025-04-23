using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfileManagement.API.Models.Request;
using ProfileManagement.Infrastructure.Data.Services;

namespace ProfileManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("generateJwtToken")]
        public IActionResult GenerateJwtToken([FromBody] LoginRequest request)
        {
            var token = _authService.GenerateJwtToken(request.Username);
            return token is not null ? Ok(new { Token = token }) : Unauthorized();
        }
    }
}
