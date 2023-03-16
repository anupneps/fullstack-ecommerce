using backend.src.Models;
using backend.src.Services.BaseService;
using backend.src.Services.ProductService;
using backend.src.DTOs;

namespace backend.src.Controllers
{
    public class ProductController : BaseController<Product, ProductReadDTO, ProductCreateDTO, ProductUpdateDTO>
    {
        public ProductController(IProductService service) : base(service)
        {
        }
    }
}
