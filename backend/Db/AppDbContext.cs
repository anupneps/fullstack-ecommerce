using backend.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace backend.Db
{
    public class AppDbContext : DbContext
    {
        static AppDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        private readonly IConfiguration _configuration;
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config) :base(options)
        {
            _configuration = config;
        }


        public DbSet<Product> Products { get; set; } = null!;
        // public DbSet<User> Users { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
    }
}
