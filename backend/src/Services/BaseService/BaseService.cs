using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.src.Helpers;
using backend.src.Repositories.BaseRepo;

namespace backend.src.Services.BaseService
{
    public class BaseService<T, TReadDto, TCreateDto, TUpdateDto>: IBaseService<T, TReadDto, TCreateDto, TUpdateDto>
    {
        protected readonly IMapper _mapper;
        protected readonly IBaseRepo<T> _repo;

        public BaseService(IMapper mapper, IBaseRepo<T> repo) {
            _mapper = mapper;
            _repo = repo;
         }

        public async Task<TReadDto> CreateOneAsync(TCreateDto create) {
            var entity = _mapper.Map<TCreateDto, T>(create);
            var result =  await _repo.CreateOneAsync(entity);
            if(result is null)
            {
                throw new Exception("Cannot create");
            }
            return _mapper.Map<T, TReadDto>(result);
         }

        public Task<bool> DeleteOneAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TReadDto>> GetAllAsync(QueryParams options)
        {
            var data = await _repo.GetAllAsync(options);
            return _mapper.Map<IEnumerable<T>, IEnumerable<TReadDto>>(data);
        }

        public async Task<TReadDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity is null)
            {
                throw new Exception("id is not found");
            }
            return _mapper.Map<T, TReadDto>(entity);
        }

        public async Task<TReadDto> UpdateOneAsync(Guid id, TUpdateDto update)
        {
            var entity = await _repo.GetByIdAsync(id);
            if(entity is null)
            {
                 throw ServiceException.NotFound();
            }
            var result = await _repo.UpdateOneAsync(id, _mapper.Map<TUpdateDto, T>(update));
            return _mapper.Map<T, TReadDto>(result);
        }

    }
}
