using backend.src.Models;
using backend.src.Services.BaseService;
using backend.src.DTOs;

namespace backend.src.Services.UserService
{
    public interface IUserService : IBaseService<User,UserReadDTO, UserCreateDTO, UserUpdateDTO >
    {
    }
}
