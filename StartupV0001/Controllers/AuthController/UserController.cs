using Core.Interfaces.User;
using Microsoft.AspNetCore.Http;
using P_StartupV0001.Helpers;
using P_StartupV0001.Models;
using P_StartupV0001.Configuration;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces.Authentication;
using Microsoft.Extensions.Options;
using P_Core.Models.Entities;

namespace P_StartupV0001.Controllers
{
    [Authorize(UserTypes = "admin")]
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        private ITokenService _tokenService;
        private IUserService _userService;
        private readonly AppSettings _appSettings;

        #region Constructors
        public UserController(
            ITokenService tokenService,
            IUserService userRepositoryService,
            IOptions<AppSettings> appSettings
            ) : base(tokenService, userRepositoryService, appSettings)
        {
            _tokenService = tokenService;
            _userService = userRepositoryService;
            _appSettings = appSettings.Value;

        }

        #endregion

        #region UserType
        #endregion

        #region Permission
        //Will return a UserType's All Permissions.
        //UserType's Id or/and UserType's Key
        [HttpGet("permissions")]
        public async Task<IActionResult> Permissions()
        {
            return null;
        }

        //Will return a spesific permission
        //Permission's Id or/and Permission's Key
        [HttpGet("permission")]
        public async Task<IActionResult> Permission()
        {
            var permissionModel = await Request.ReadFromJsonAsync<Permission>();

            return null;
        }

        //Will Create a new permission
        //new Permission's Key and Description
        [HttpPost("permission")]
        public async Task<IActionResult> PermissionPost()
        {
            var permissionModel = await Request.ReadFromJsonAsync<Permission>();
            return null;
        }

        //Will Update an existing permission
        //permission's current Key and new Description
        [HttpPatch("permission")]
        public async Task<IActionResult> PermissionPatch()
        {
            var permissionModel = await Request.ReadFromJsonAsync<Permission>();
            return null;
        }

        //Will Delete a permission
        //permission's Key
        [HttpDelete("permission")]
        public async Task<IActionResult> PermissionDelete()
        {
            var permissionModel = await Request.ReadFromJsonAsync<Permission>();
            return null;
        }
        #endregion

    }
}
