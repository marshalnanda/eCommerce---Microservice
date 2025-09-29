using AutoMapper;
using eCommerce.Core.Entities;
using eCommerce.Core.Entities.DTO;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Service
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository=userRepository;
            _mapper = mapper;
        }
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
          ApplicationUser? user= await _userRepository.GetUserByEmailandPassword(loginRequest.Email, loginRequest.Password);
            if (user == null) { return null; }
            //return new AuthenticationResponse(user.UserId, user.Email, user.PersonName, user.Gender, "DummyToken", success: true);
            return _mapper.Map<AuthenticationResponse>(user) with { success=true,Token="token" };
        }

        public async Task<AuthenticationResponse?> Resgister(RegisterRequest registerRequest)
        {
            //ApplicationUser? user = new ApplicationUser()
            //{
            //    PersonName = registerRequest.PersonName,
            //    Email = registerRequest.Email,
            //    Password = registerRequest.Password,
            //    Gender = registerRequest.Gender.ToString()
            //};
            ApplicationUser? user = _mapper.Map<ApplicationUser>(registerRequest);
            ApplicationUser? registeredUser= await _userRepository.AddUser(user);
            if (registeredUser == null)
            {
                return null;
            }
            //return new AuthenticationResponse(registeredUser.UserId, registeredUser.Email, registeredUser.PersonName,
            //    registeredUser.Gender, "DummyToken2", success: true);
            return _mapper.Map<AuthenticationResponse>(user) with { success = true, Token = "token2" };

        }
    }
}
