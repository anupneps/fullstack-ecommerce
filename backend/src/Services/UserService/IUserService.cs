using backend.src.DTOs;
using backend.src.Models;
using backend.src.Services.BaseService;

namespace backend.src.Services.UserService
{
    public interface IUserService : IBaseService<User, UserReadDTO, UserCreateDTO, UserUpdateDTO>
    {
    }
}
