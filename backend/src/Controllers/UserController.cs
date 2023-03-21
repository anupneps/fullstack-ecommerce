using backend.src.Models;
using backend.src.Services.BaseService;
using backend.src.Services.UserService;
using backend.src.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers
{
    [Authorize]
    public class UserController : BaseController<User, UserReadDTO, UserCreateDTO, UserUpdateDTO>
    {
        public UserController(IUserService service) : base(service)
        {
        }

        [AllowAnonymous]
        public override async Task<ActionResult<UserReadDTO?>> CreateOne(UserCreateDTO create)
        {
            return await base.CreateOne(create);
        }

        [Authorize("AdminOnly")]
        [HttpDelete("{id}")]
        public override async Task<ActionResult<UserReadDTO>> DeleteOne(int id)
        {
            return Ok(await _service.DeleteOneAsync(id));
        }

    }
}
