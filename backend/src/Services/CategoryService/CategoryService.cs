﻿using AutoMapper;
using backend.src.Db;
using backend.src.DTOs;
using backend.src.Models;
using backend.src.Repositories.BaseRepo;
using backend.src.Repositories.CategoryRepo;
using backend.src.Repositories.ProductRepo;
using backend.src.Services.BaseService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace backend.src.Services.CategoryService
{
    public class CategoryService : BaseService<Category, CategoryReadDTO, CategoryCreateDTO, CategoryUpdateDTO>, ICategoryService
    {
        /* Need to fix the following !!! */

        //public async Task<IEnumerable<ProductReadDTO>> GetProductByCategory(int id)
        //{
        //    var category = await _repo.GetProductByCategory(id);
        //    return category is null
        //        ? throw new Exception("id is not found")
        //        : _mapper.Map<IEnumerable<Product>, IEnumerable<ProductReadDTO>>(category);
        //}
        public CategoryService(IMapper mapper, ICategoryRepo repo) : base(mapper, repo)
        {
        }

        public Task<IEnumerable<ProductReadDTO>> GetProductByCategory(int id)
        {
            throw new NotImplementedException();
        }
    }

}