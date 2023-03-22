using AutoMapper;
using backend.src.DTOs;
using backend.src.Models;
using backend.src.Repositories.UserRepo;
using backend.src.Services.BaseService;
using backend.src.Services.ServiceHash;

namespace backend.src.Services.UserService
{
    public class UserService : BaseService<User, UserReadDTO, UserCreateDTO, UserUpdateDTO>, IUserService
    {
        private readonly IServiceHash _hash;

        public UserService(IMapper mapper, IUserRepo repo, IServiceHash hash) : base(mapper, repo)
        {
            _hash = hash;
        }

        public override async Task<UserReadDTO> CreateOneAsync(UserCreateDTO create)
        {
            _hash.CreateHashData(create.Password, out byte[] passwodHash, out byte[] salt);
            var user = _mapper.Map<UserCreateDTO, User>(create);
            user.Password = passwodHash;
            user.Salt = salt;

            var result = await _repo.CreateOneAsync(user);

            if (result is null)
            {
                throw new Exception("Cannot create User, Try again !");
            }
            return _mapper.Map<User, UserReadDTO>(result);
        }

        public override async Task<UserReadDTO> UpdateOneAsync(int id, UserUpdateDTO update)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) { throw new Exception("User doesnot exists !"); }

            _hash.CreateHashData(update.Password, out byte[] passwordHash, out byte[] salt);
            var updatedUser = _mapper.Map(update, user);
            updatedUser.Password = passwordHash;
            updatedUser.Salt = salt;

            var result = await _repo.UpdateOneAsync(id, updatedUser);

            return _mapper.Map<User, UserReadDTO>(result);
        }

    }
}

