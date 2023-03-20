using backend.src.DTOs;

namespace backend.src.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<string?> LogInAsync(AuthenticationDTO auth);
    }
}
