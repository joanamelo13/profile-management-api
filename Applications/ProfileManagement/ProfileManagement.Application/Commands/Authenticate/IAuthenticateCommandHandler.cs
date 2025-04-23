using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileManagement.Application.Commands.Authenticate
{
    public interface IAuthenticateCommandHandler
    {
        Task<string?> AuthenticateAsync(string username, string password);
    }
}
