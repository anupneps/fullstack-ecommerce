using backend.src.Db;
using backend.src.Models;
using backend.src.Repositories.BaseRepo;

namespace backend.src.Repositories.CategoryRepo
{
    public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(AppDbContext context) : base(context)
        {
        }
    }

}
