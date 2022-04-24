using CryptSwitch.Builders.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CryptSwitch.Authentication
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public IdentityService(UserManager<IdentityUser> userManager, JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }
        public async Task<AuthenticationResults> Register(string email, string password)
        {
            var existing = await _userManager.FindByNameAsync(email);
            if (existing != null)
            {
                return new AuthenticationResults
                {
                    ErrorMessages = new[] { "User already Exists" }
                };
            }
            var newUser = new IdentityUser
            {
                Email = email,
                UserName = email,
            };

            var createdUser = await _userManager.CreateAsync(newUser,password);

            if(!createdUser.Succeeded)
            {
                return new AuthenticationResults
                {
                    ErrorMessages = createdUser.Errors.Select(x => x.Description)
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                    new Claim("id", newUser.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) // thinking of user aws kms encryption signature here..
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResults
            {
                Success = true,
                token = tokenHandler.WriteToken(token)
            };
        }
    }
}
