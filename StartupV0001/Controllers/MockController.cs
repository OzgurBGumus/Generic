using Core.Interfaces.Authentication;
using Core.Interfaces.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using P_StartupV0001.Configuration;
using P_StartupV0001.Helpers;

namespace P_StartupV0001.Controllers
{
    [Helpers.Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MockController : BaseController
    {
        public MockController(ITokenService tokenService, IUserService userRepositoryService, IOptions<AppSettings> appSettings) : base(tokenService, userRepositoryService, appSettings)
        {
        }

        [HttpPost("resetMockDB")]
        public async Task<IActionResult> resetMockDB()
        {
            return Ok("Mock Database is reinstalled.");
        }
    }
}
