﻿using eCommerce.Core.Entities.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (registerRequest == null) return BadRequest("Invalid Registration Data");
           AuthenticationResponse? authenticationResponse= await _userService.Resgister(registerRequest);
            if (authenticationResponse == null || authenticationResponse.success == false) return BadRequest(authenticationResponse);
            return Ok(authenticationResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(eCommerce.Core.Entities.DTO.LoginRequest loginRequest){
            if (loginRequest == null) return BadRequest("Invalid Login Data");
            AuthenticationResponse? authenticationResponse= await _userService.Login(loginRequest);
            if (authenticationResponse == null || authenticationResponse.success == false) return Unauthorized(authenticationResponse);
            return Ok(authenticationResponse);

        }
    }
}
