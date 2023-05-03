using backend.src.Models;
using backend.src.Services.BaseService;
using backend.src.Services.ProductService;
using backend.src.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace backend.src.Controllers
{
    [Authorize]
    public class ProductController : BaseController<Product, ProductReadDTO, ProductCreateDTO, ProductUpdateDTO>
    {
        public ProductController(IProductService service) : base(service)
        {
        }
    }
}
