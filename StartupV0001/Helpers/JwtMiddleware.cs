using Core.Interfaces.Authentication;
using Core.Interfaces.User;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_StartupV0001.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, ITokenService tokenService, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = tokenService.ValidateToken(_appSettings.JwtSecret, token);
            if(context.Items["User"] != null)
            {
                if(((StartupV0001.Models.User)context.Items["User"]).Id != userId)
                {
                    context.Items["User"] = null;
                }
            }
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetUser(userId.Value);
            }

            await _next(context);
        }
    }
}
