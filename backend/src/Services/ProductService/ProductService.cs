using AutoMapper;
using backend.src.DTOs;
using backend.src.Helpers;
using backend.src.Models;
using backend.src.Repositories.ProductRepo;
using backend.src.Services.BaseService;

namespace backend.src.Services.ProductService
{
    public class ProductService : BaseService<Product, ProductReadDTO, ProductCreateDTO, ProductUpdateDTO>, IProductService
    {
        public ProductService(IMapper mapper, IProductRepo repo) : base(mapper, repo)
        {
        }

        public override async Task<ProductReadDTO> UpdateOneAsync(int id, ProductUpdateDTO update)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity is null)
            {
                throw ServiceException.NotFound();
            }

            var result = await _repo.UpdateOneAsync(id, _mapper.Map(update, entity));
            return _mapper.Map<Product, ProductReadDTO>(result);
        }
    }
}
