using backend.src.Db;
using backend.src.Models;
using backend.src.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace backend.src.Repositories.CategoryRepo
{
    public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(AppDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Category>> GetAllAsync(QueryParams options)
        {
            var categories = _context.Categories
                .AsNoTracking()
                .Include(c => c.Image)
                .Include(p => p.Products);
               

            var query = categories.AsQueryable();

            if (options.Sort.Trim().Length > 0)
            {
                if (query.GetType().GetProperty(options.Sort) != null)
                {
                    query = query.OrderBy(e => e.GetType().GetProperty(options.Sort));
                }
            }
            if (!string.IsNullOrEmpty(options.Search))
            {
               query = query.Where(p=>p.Name.Contains(options.Search));
            }

            if (options.Offset < 0) { options.Offset = 0; }
            if (options.Limit < 0) { options.Limit = 0; }

            query = query.Skip(options.Offset).Take(options.Limit);
            return await query.ToArrayAsync();
        }

        public override async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.Include(c=> c.Image).Include(p=>p.Products).FirstOrDefaultAsync(c=> c.Id == id);
        }

        public async Task<IEnumerable<Product>?> GetProductByCategory(int id)
        {
            var category = await _context.Categories.Include(p=>p.Products).FirstOrDefaultAsync(c => c.Id == id);
            if (category is null)
                return null;
            return category.Products.ToArray();

        }

        
    }

}
