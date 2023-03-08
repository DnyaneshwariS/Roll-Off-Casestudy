using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;

using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Text;


namespace RollOff_Test4API.Services
{
    #region JWTservice

    public class JWTService
    {
        public string SecretKey { get; set; }
        public int TokenDuration { get; set; }
        private readonly IConfiguration _config;
        public JWTService(IConfiguration config)
        {
            _config = config;
            this.SecretKey = _config.GetSection("jwtconfig").GetSection("Key").Value;
            this.TokenDuration = Int32.Parse(config.GetSection("jwtconfig").GetSection("Duration").Value);
        }



        public string GenerateToken(string FirstName, string LastName, string Email, string Role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SecretKey));
            var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var payload = new[]
            {
              new Claim("FirstName",FirstName),
              new Claim("LastName",LastName),
              new Claim("Email",Email),
              new Claim("Role",Role),
            };
            var jwtToken = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: payload,
                expires: DateTime.Now.AddMinutes(TokenDuration),
                signingCredentials: signature
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);

        }


    }

    #endregion
}
