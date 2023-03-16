using AutoMapper;
using backend.src.Db;
using backend.src.DTOs;
using backend.src.Models;
using backend.src.Repositories.BaseRepo;
using backend.src.Repositories.CategoryRepo;
using backend.src.Repositories.ProductRepo;
using backend.src.Services.BaseService;

namespace backend.src.Services.CategoryService
{
    public class CategoryService : BaseService<Category, CategoryReadDTO, CategoryCreateDTO, CategoryUpdateDTO>, ICategoryService
    {
        public CategoryService(IMapper mapper, ICategoryRepo repo) : base(mapper, repo)
        {
        }
    }

}
