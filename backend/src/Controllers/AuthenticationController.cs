using backend.src.DTOs;
using backend.src.Services.AuthenticationService;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers
{
    [ApiController]
    [Route("api/v1/authenticaton")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public AuthenticationController(IAuthenticationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<string?> LogInAsync(AuthenticationDTO auth)
        {
            return await _service.LogInAsync(auth);
        }

    }
}
