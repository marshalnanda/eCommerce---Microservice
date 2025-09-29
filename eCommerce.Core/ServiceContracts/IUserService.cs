using eCommerce.Core.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.ServiceContracts
{
    public interface IUserService
    {
        Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
        Task<AuthenticationResponse?> Resgister(RegisterRequest registerRequest);
    }
}
