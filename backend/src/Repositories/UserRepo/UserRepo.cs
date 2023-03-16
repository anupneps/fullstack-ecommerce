using backend.src.Db;
using backend.src.Models;
using backend.src.Repositories.BaseRepo;

namespace backend.src.Repositories.UserRepo
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(AppDbContext context) : base(context)
        {
        }
    }
}
