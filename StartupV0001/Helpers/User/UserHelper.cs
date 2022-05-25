using Core.Interfaces.Authentication;
using Core.Interfaces.User;
using Core.Models.Entities;
using Microsoft.Extensions.Options;

namespace P_StartupV0001.Helpers.User
{
    public class UserHelper
    {
        private ITokenService _tokenService;
        private IUserService _userService;
        private HttpRequest _request;
        private AppSettings _appSettings;
        public UserHelper(ITokenService tokenService, IUserService userRepositoryService, IOptions<AppSettings> appSettings)
        {
            _tokenService = tokenService;
            _userService = userRepositoryService;
            _appSettings = appSettings.Value;
        }
        public void updateRequest(HttpRequest request)
        {
            _request = request;
        }
        public UserAbstract GetCurrentUser()
        {
            var token = _request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var id = _tokenService.ValidateToken(_appSettings.JwtSecret, token);
            if (id == null) return null;
            return _userService.GetUser(id);
        }
    }
}
