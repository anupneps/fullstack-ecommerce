using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.src.Repositories.BaseRepo;

namespace backend.src.Services.BaseService
{
    public interface IBaseService<T, TReadDto, TCreateDto, TUpdateDto>
    {
        Task<IEnumerable<TReadDto>> GetAllAsync(QueryParams options);
        Task<TReadDto?> GetByIdAsync(string id);
        Task<TReadDto> UpdateOneAsync(string id, TUpdateDto update);
        Task<bool> DeleteOneAsync(string id);
        Task<TReadDto> CreateOneAsync (TCreateDto create);   
    }
}
