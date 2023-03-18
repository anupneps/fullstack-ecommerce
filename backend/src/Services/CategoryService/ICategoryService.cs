using backend.src.DTOs;
using backend.src.Models;
using backend.src.Repositories.BaseRepo;
using backend.src.Services.BaseService;

namespace backend.src.Services.CategoryService

{
    public interface ICategoryService : IBaseService<Category, CategoryReadDTO, CategoryCreateDTO, CategoryUpdateDTO>
    {
        Task<IEnumerable<ProductReadDTO>> GetProductByCategory(int id);
    }
}
