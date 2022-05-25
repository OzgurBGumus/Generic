using Core.Interfaces.Authentication;
using Core.Interfaces.User;
using Core.Models.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using P_StartupV0001.Helpers;
using P_StartupV0001.Helpers.User;
using StartupV0001.Configuration;
using StartupV0001.Models;
using System.Text;
using USER = User;
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddCoreServices(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());


app.UseMiddleware<JwtMiddleware>();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.MapGet("/", () => "Hello World");

#region Auth
    app.MapGet("/userInfo", async (HttpContext http, ITokenService tokenService, IUserService userRepositoryService) =>
    {
        
    });
#endregion
app.MapGet("/doaction", (Func<string>)(() => "Action Succeeded"));
app.Run();
