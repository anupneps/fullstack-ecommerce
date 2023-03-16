using AutoMapper;
using backend.src.Models;
using backend.src.Repositories.BaseRepo;
using backend.src.Services.BaseService;
using backend.src.DTOs;
using backend.src.Repositories.UserRepo;

namespace backend.src.Services.UserService
{
    public class UserService : BaseService<User, UserReadDTO, UserCreateDTO, UserUpdateDTO>, IUserService
    {
        public UserService(IMapper mapper, IUserRepo repo) : base(mapper, repo)
        {
        }
    }
}

