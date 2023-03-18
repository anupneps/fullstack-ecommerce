using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using backend.src.Db;
using backend.src.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Repositories.BaseRepo
{
    public class BaseRepo<T> : IBaseRepo<T> where T : BaseModel
    {
        protected readonly AppDbContext _context;

        public BaseRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T?> CreateOneAsync(T create)
        {
            await _context.Set<T>().AddAsync(create);
            await _context.SaveChangesAsync();
            return create;
        }

        public async Task<bool> DeleteOneAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if(entity is null)
            {
                return false;
            }else
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(QueryParams options)
        {
            var query = _context.Set<T>().AsNoTracking();
            if (options.Sort.Trim().Length > 0)
            {
                if (query.GetType().GetProperty(options.Sort) != null)
                {
                   query =  query.OrderBy(e => e.GetType().GetProperty(options.Sort));
                }
            }
            if(options.Offset < 0) { options.Offset = 0; }
            if (options.Limit < 0) { options.Limit = 0; }

            query = query.Skip(options.Offset).Take(options.Limit);

            return await query.ToArrayAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateOneAsync(int id, T update)
        {
            var entity = update;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
