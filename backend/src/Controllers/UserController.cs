using backend.src.Models;
using backend.src.Services.BaseService;
using backend.src.Services.UserService;
using backend.src.DTOs;

namespace backend.src.Controllers
{
    public class UserController : BaseController<User, UserReadDTO, UserCreateDTO, UserUpdateDTO>
    {
        public UserController(IUserService service) : base(service)
        {
        }
    }
}
