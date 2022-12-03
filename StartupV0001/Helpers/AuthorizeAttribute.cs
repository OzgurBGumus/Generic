using Authentication;
using Core.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;
using User;

namespace P_StartupV0001.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public string UserTypes { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var user = (UserAbstract)context.HttpContext.Items["User"];
            
            if (user == null || token == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }
            if (!string.IsNullOrEmpty(UserTypes))
            {
                UserTypes = Regex.Replace(UserTypes, @"\s+", "").ToLower();
                var userTypes = UserTypes.Split(',');
                for(var i=0; i<userTypes.Length; i++)
                {
                    if (user.UserTypes.Where(ut => ut.Key.ToLower().Equals(userTypes[i])).Any())
                    {
                        return;
                    }
                }
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
