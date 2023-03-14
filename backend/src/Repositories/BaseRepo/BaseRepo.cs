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
            return create;
        }

        public async Task<bool> DeleteOneAsync(string id)
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

        public async Task<IEnumerable<T>> GetAllAsync(QueryParams options)
        {
            var query = _context.Set<T>().AsNoTracking();
            if (options.Sort.Trim().Length > 0)
            {
                if (query.GetType().GetProperty(options.Sort) != null) 
                {
                    query.OrderBy(e => e.GetType().GetProperty(options.Sort));
                } 
                query.Take(options.Limit).Skip(options.Skip);
            }
            return await query.ToArrayAsync();
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateOneAsync(string id, T update)
        {
            var entity = update;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
