using backend.src.DTOs;
using backend.src.Models;
using backend.src.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace backend.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class CategoriesController : BaseController<Category, CategoryReadDTO, CategoryCreateDTO, CategoryUpdateDTO>
    {
        private ICategoryService _categoryService => (ICategoryService)_service; // explict casting of child interface
        public CategoriesController(ICategoryService service) : base(service)
        {
        }

        [HttpGet("{id}/products")]
        public async Task<ActionResult<Product>> GetProductByCategory(int id)
        {
            var products = await _categoryService.GetProductByCategory(id);
            return Ok(products);
        }
    }
}
