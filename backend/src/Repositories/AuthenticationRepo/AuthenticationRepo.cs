using backend.src.Db;
using backend.src.DTOs;
using backend.src.Models;
using backend.src.Services.ServiceHash;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Repositories.AuthenticationRepo
{
    public class AuthenticationRepo : IAuthenticationRepo
    {
        private readonly AppDbContext _context;
        private readonly IServiceHash _hash;

        public AuthenticationRepo(AppDbContext context, IServiceHash hash)
        {
            _context = context;
            _hash = hash;
        }

        public async Task<User?> LogInAsync(AuthenticationDTO auth)
        {
            _hash.CreateHashData(auth.Password, out byte[] password, out byte[] salt);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(auth.Email));

            if (_hash.CompareHashData(auth.Password, user!.Password, user.Salt))
            {
                return user;
            }
            return null;
        }
    }
}
