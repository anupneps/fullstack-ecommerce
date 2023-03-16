using backend.src.Models;
using backend.src.Services.BaseService;
using backend.src.DTOs;

namespace backend.src.Services.ProductService
{
    public interface IProductService : IBaseService<Product, ProductReadDTO, ProductCreateDTO, ProductUpdateDTO>
    {
    }
}
