using backend.src.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Db
{
    public static class EntityConfigExtension
    {
        public static void AddEntityConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<Role>();
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Role).HasColumnType("role");
                entity.HasIndex(e => e.Email).IsUnique();
            });
        }

        public static void UserTimeStampDefault(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(s => s.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<User>().Property(s => s.LastUpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }

        public static void ProductTimeStampDefault(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(s => s.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Product>().Property(s => s.LastUpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }

        public static void CategoryTimeStampDefault(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(s => s.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Category>().Property(s => s.LastUpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }

        public static void ImageTimeStampDefault(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>().Property(s => s.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Image>().Property(s => s.LastUpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
