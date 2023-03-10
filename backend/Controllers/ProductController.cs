using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{  
    public class ProductController : CrudController<Product, ProductDTO>
    {
        public ProductController(IcrudServices<Product, ProductDTO> services) : base(services)
        {
        }
    }
}
