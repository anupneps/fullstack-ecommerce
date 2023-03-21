﻿using AutoMapper;
using backend.src.Models;
using backend.src.Repositories.BaseRepo;
using backend.src.Services.BaseService;
using backend.src.DTOs;
using backend.src.Repositories.UserRepo;
using backend.src.Services.ServiceHash;
using System.Text;
using System.Collections;

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
            user.Password = Encoding.ASCII.GetString(passwodHash); // need to fix here 
            Console.WriteLine(user.Password);
            user.Salt = salt;

            var result = await _repo.CreateOneAsync(user);

            if (result is null)
            {
                throw new Exception("Cannot create User, Try again !");
            }
            return _mapper.Map<User, UserReadDTO>(result);
        }
    }
}

