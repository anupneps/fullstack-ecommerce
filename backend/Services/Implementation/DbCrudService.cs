using backend.Db;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.Implementation
{
    public class DbCrudService<TModel, TDto> : IcrudServices<TModel, TDto> where TModel:BaseModel, new() where TDto : BaseDTO<TModel>
    {
        protected readonly AppDbContext _dbContext;

        public DbCrudService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TModel> CreateAsync(TDto request)
        {
            var item = new TModel();
            request.UpdateModel(item);
            _dbContext.Add(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ICollection<TModel>> GetAllAsync()
        {
            return await _dbContext.Set<TModel>().AsNoTracking().ToListAsync(); 
        }

        public Task<TModel> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> UpdateAsync(Guid id, TDto request)
        {
            throw new NotImplementedException();
        }
    }

}
