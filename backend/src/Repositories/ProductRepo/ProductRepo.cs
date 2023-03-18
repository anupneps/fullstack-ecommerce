using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.src.Db;
using backend.src.Models;
using backend.src.Repositories.BaseRepo;
using backend.src.Repositories.ProductRepo;
using Microsoft.EntityFrameworkCore;

namespace Api.src.Repositories.ProductRepo
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        public ProductRepo(AppDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Product>> GetAllAsync(QueryParams options)
        {
            var products = _context.Products.AsNoTracking()
                .Include(c => c.Category).ThenInclude(i=> i.Image)
                .Include(s=>s.Images);

            var query = products.AsQueryable();
           

            if (options.Sort.Trim().Length > 0)
            {
                if (options.Sort.Trim().Length > 0)
                {
                    if (query.GetType().GetProperty(options.Sort) != null)
                    {
                        query = query.OrderBy(e => e.GetType().GetProperty(options.Sort));
                    }
                }
                if (!string.IsNullOrEmpty(options.Search))
                {
                    query = query.Where(p => p.Title.Contains(options.Search));
                }

                if (options.Offset < 0) { options.Offset = 0; }
                if (options.Limit < 0) { options.Limit = 0; }

                query = query.Skip(options.Offset).Take(options.Limit);
                return await query.ToArrayAsync();
            }
            return await query.ToArrayAsync();
        }

        public override async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.Category).ThenInclude(i=>i.Image).Include(p=>p.Images).FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}