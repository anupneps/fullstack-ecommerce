using AutoMapper;
using backend.src.DTOs;
using backend.src.Models;
using backend.src.Repositories.CategoryRepo;
using backend.src.Services.BaseService;

namespace backend.src.Services.CategoryService
{
    public class CategoryService : BaseService<Category, CategoryReadDTO, CategoryCreateDTO, CategoryUpdateDTO>, ICategoryService
    {
        public CategoryService(IMapper mapper, ICategoryRepo repo) : base(mapper, repo)
        {
        }

        public async Task<IEnumerable<ProductReadDTO>> GetProductByCategory(int id)
        {
            var category = await ((ICategoryRepo)_repo).GetProductByCategory(id);
            return (category is null
                ? throw new Exception("id is not found")
                : _mapper.Map<IEnumerable<Product>, IEnumerable<ProductReadDTO>>(category));
        }
    }

}
