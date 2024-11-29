using JwtWebApi.Helpers;
using JwtWebApi.Models;

namespace JwtWebApi.Services
{
    public interface IAuthService
    {
        string Authenticate(UserLogin userLogin);
    }

    public class AuthService : IAuthService
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expireMinutes;

        public AuthService(IConfiguration configuration)
        {
            _secretKey = configuration["Jwt:SecretKey"];
            _issuer = configuration["Jwt:Issuer"];
            _audience = configuration["Jwt:Audience"];
            _expireMinutes = int.Parse(configuration["Jwt:ExpireMinutes"]);
        }

        public string Authenticate(UserLogin userLogin)
        {
            // Validate user (for demonstration, replace with actual user validation logic)
            if (userLogin.Username == "admin" && userLogin.Password == "password")
            {
                return JwtHelper.GenerateJwtToken(userLogin.Username, _secretKey, _issuer, _audience, _expireMinutes);
            }
            return null;
        }
    }
}
