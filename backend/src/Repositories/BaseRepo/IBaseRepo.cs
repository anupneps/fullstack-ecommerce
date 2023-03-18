using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace backend.src.Repositories.BaseRepo
{
    public interface IBaseRepo<T>
    {
        Task<IEnumerable<T>> GetAllAsync(QueryParams options);
        Task<T?> GetByIdAsync(int id);
        Task<T> UpdateOneAsync(int id, T update);
        Task<bool> DeleteOneAsync(int id);
        Task<T?> CreateOneAsync (T create);
    }

    public class QueryParams
    {
        public string Sort { get; set; } = string.Empty;
        public string Search { get; set; } = string.Empty;
        public SortBy SortBy { get; set; }
        public int Limit { get; set; } = 10;
        public int Offset { get; set; } = 0;
    }

    public enum SortBy
    {
        ASC,
        DESC
    }
}
