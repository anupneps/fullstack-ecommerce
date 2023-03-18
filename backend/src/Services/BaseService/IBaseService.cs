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
        Task<TReadDto?> GetByIdAsync(int id);
        Task<TReadDto> UpdateOneAsync(int id, TUpdateDto update);
        Task<bool> DeleteOneAsync(int id);
        Task<TReadDto> CreateOneAsync (TCreateDto create);   
    }
}
