using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APICLass.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IConfiguration _config;

        public AuthServices(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateJWT()
        {
            //var claims = new List<Claim>();

            //claims.Add(new Claim(ClaimTypes.Name, "Oluwatobi"));
            //claims.Add(new Claim(ClaimTypes.Email, "oluwatobi@sample.com"));


            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config.GetSection("JWT:KEY").Value);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var securityToken = new JwtSecurityToken(
                
                expires: DateTime.UtcNow.AddDays(Convert.ToInt32(_config.GetSection("JWT:LifeSpan").Value)),
                signingCredentials: signingCredentials
                );

            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
