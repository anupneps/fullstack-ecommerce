using AutoMapper;
using backend.src.Models;
using backend.src.Repositories.BaseRepo;
using backend.src.Repositories.ProductRepo;
using backend.src.Services.BaseService;
using backend.src.DTOs;

namespace backend.src.Services.ProductService
{
    public class ProductService : BaseService<Product, ProductReadDTO, ProductCreateDTO, ProductUpdateDTO>, IProductService
    {
        public ProductService(IMapper mapper, IProductRepo repo) : base(mapper, repo)
        {
        }
    }
}
