using backend.src.DTOs;
using backend.src.Models;
using backend.src.Repositories.AuthenticationRepo;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace backend.src.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepo _repo;
        private readonly IConfiguration _config;

        public AuthenticationService(IAuthenticationRepo repo, IConfiguration config) 
        { 
            _repo = repo; 
            _config = config;
        }

        public async Task<string?> LogInAsync(AuthenticationDTO auth)
        {
            var user = await _repo.LogInAsync(auth);
            if(user == null) { return null; }
            return CreateToken(user);
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                //new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            var secret = _config.GetValue<string>("AppSettings:Token");
            var tokenHander = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secret!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials,
                Expires = DateTime.Now.AddDays(7)
            };
            var token = tokenHander.CreateToken(tokenDescriptor);
            return tokenHander.WriteToken(token);
        }

    }
}
