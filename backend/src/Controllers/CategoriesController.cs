using backend.src.DTOs;
using backend.src.Models;
using backend.src.Repositories.CategoryRepo;
using backend.src.Services.BaseService;
using backend.src.Services.CategoryService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers
{
    
    public class CategoriesController : BaseController<Category, CategoryReadDTO, CategoryCreateDTO, CategoryUpdateDTO>
    {
       /* cannot get access to the method of GetProductByCategory(int id) though ICategoryService service .... working on the way to fix it */
        
        private readonly ICategoryRepo _categoryRepo; 

        public CategoriesController(ICategoryService service, ICategoryRepo categoryRepo) : base(service)
        {
            _categoryRepo = categoryRepo;
        }


        [HttpGet("{id}/products")]
        public async Task<ActionResult<Product>> GetProductByCategory(int id)
        {
            var products = await _categoryRepo.GetProductByCategory(id);

            return Ok(products);
        }


    }
}
