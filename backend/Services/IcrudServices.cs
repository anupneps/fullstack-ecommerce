namespace backend.Services
{
    public interface IcrudServices <TModel, TDto>
    {
        Task<TModel?> CreateAsync(TDto request);
        Task<TModel?> GetAsync(Guid id);
        Task<ICollection<TModel>> GetAllAsync();
        Task<TModel?> UpdateAsync(Guid id, TDto request);
        Task<bool> DeleteAsync(Guid id);
    }
}
