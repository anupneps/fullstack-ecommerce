using backend.src.DTOs;
using backend.src.Services.AuthenticationService;
using backend.src.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backend.src.Controllers
{
    [ApiController]
    [Route("api/v1/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;
        private readonly IUserService _userService;

        public AuthenticationController(IAuthenticationService service, IUserService userService)
        {
            _service = service;
            _userService = userService;
        }

        [HttpPost]
        public async Task<string?> LogInAsync(AuthenticationDTO auth)
        {
            return await _service.LogInAsync(auth);
        }

        [HttpGet("profile")]
        public async Task<ActionResult<UserReadDTO>> GetSession()
        {
            var authenticatedUser = HttpContext.User;
            var id = authenticatedUser.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == null) { return Unauthorized(); }
            var user = await _userService.GetByIdAsync(int.Parse(id));
            return Ok(user);
        }
    }
}
