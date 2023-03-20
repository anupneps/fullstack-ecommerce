using backend.src.DTOs;
using backend.src.Models;

namespace backend.src.Repositories.AuthenticationRepo
{
    public interface IAuthenticationRepo
    {
        Task<User?> LogInAsync(AuthenticationDTO auth);
    }
}
