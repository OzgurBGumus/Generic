using Core.Models.Entities;

namespace Core.Interfaces.Authentication
{
    public interface ITokenService
    {
        string BuildToken(string _key, string issuer, UserAbstract user);
        int? ValidateToken(string _key, string? token);
        int? GetUserIdFromToken(string _secret, string token);
    }
}
