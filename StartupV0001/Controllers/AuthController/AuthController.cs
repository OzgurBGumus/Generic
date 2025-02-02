﻿using Core.Interfaces.Authentication;
using Core.Interfaces.User;
using Core.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using P_StartupV0001.Configuration;
using P_StartupV0001.Helpers;
using P_StartupV0001.Helpers.User;

namespace P_StartupV0001.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class AuthController : BaseController
    {
        private ITokenService _tokenService;
        private IUserService _userService;
        private readonly AppSettings _appSettings;
        
        public AuthController(
            ITokenService tokenService, 
            IUserService userRepositoryService, 
            IOptions<AppSettings> appSettings
            ):base(tokenService, userRepositoryService, appSettings)
        {
            _tokenService = tokenService;
            _userService = userRepositoryService;
            _appSettings = appSettings.Value;
            
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            UserAbstract userDto;
            var userModel = await Request.ReadFromJsonAsync<StartupV0001.Models.User>();
            userDto = _userService.GetUserWithUserNameAndPassword(userModel);
            if (userDto == null)
            {
                Response.StatusCode = 401;
                return null;
            }

            var token = _tokenService.BuildToken(_appSettings.JwtSecret, _appSettings.JwtIssuer, userDto);
            userDto.JwtToken = token;
            return Ok(userDto);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register()
        {
            var userModel = await Request.ReadFromJsonAsync<StartupV0001.Models.User>();
            var response = _userService.CreateUser(userModel);

            return Ok(response);
        }

        [Authorize(UserTypes = "user")]
        [HttpGet("user")]
        public async Task<IActionResult> User()
        {
            return Ok(base.CurrentUser());
        }

        [HttpPost("resetPasswordRequest")]
        public async Task<IActionResult> ResetPasswordRequest()
        {
            var userModel = await Request.ReadFromJsonAsync<StartupV0001.Models.User>();
            var response = _userService.ResetPasswordRequest(userModel.Email);
            return Ok(response);
        }

        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword()
        {
            var userModel = await Request.ReadFromJsonAsync<StartupV0001.Models.User>();
            var response = _userService.ResetPassword(userModel.PasswordResetToken, userModel.UserName, userModel.Password);
            return Ok(response);
        }
    }
}
