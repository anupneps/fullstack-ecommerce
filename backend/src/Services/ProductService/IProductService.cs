using backend.src.DTOs;
using backend.src.Models;
using backend.src.Services.BaseService;

namespace backend.src.Services.ProductService
{
    public interface IProductService : IBaseService<Product, ProductReadDTO, ProductCreateDTO, ProductUpdateDTO>
    {

    }
}
