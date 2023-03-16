using backend.src.DTOs;
using backend.src.Models;
using backend.src.Services.CategoryService;
using Microsoft.AspNetCore.Components;

namespace backend.src.Controllers
{
    [Route("api/v1/[controller]")]
    public class CategoriesController : BaseController<Category, CategoryReadDTO, CategoryCreateDTO, CategoryUpdateDTO>
    {
      
        public CategoriesController(ICategoryService service) : base(service)
        {
        }
    }
}
