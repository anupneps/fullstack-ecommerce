using backend.src.Db;
using backend.src.DTOs;
using backend.src.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Repositories.AuthenticationRepo
{
    public class AuthenticationRepo : IAuthenticationRepo
    {
        private readonly AppDbContext _context;

        public AuthenticationRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> LogInAsync(AuthenticationDTO auth)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(auth.Email));
            return user;
        }
    }
}
