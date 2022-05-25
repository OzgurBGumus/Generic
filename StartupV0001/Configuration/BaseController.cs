using Core.Interfaces.Authentication;
using Core.Interfaces.User;
using Core.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using P_StartupV0001.Helpers;
using P_StartupV0001.Helpers.User;

namespace P_StartupV0001.Configuration
{
    public class BaseController : ControllerBase
    {
        private UserHelper _userHelper;
        public BaseController(
            ITokenService tokenService,
            IUserService userRepositoryService,
            IOptions<AppSettings> appSettings
            )
        {
            _userHelper = new UserHelper(tokenService, userRepositoryService, appSettings);
        }
        public UserAbstract CurrentUser()
        {
            _userHelper.updateRequest(Request);
            return _userHelper.GetCurrentUser();
        }
    }
}
