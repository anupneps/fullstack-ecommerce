using backend.src.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace backend.src.Db
{
    public class AppDbContextChangeInterceptor : SaveChangesInterceptor
    {
        public void UpdateTimestamps(DbContextEventData eventData)
        {
            var entities = eventData.Context!.ChangeTracker.Entries()
                .Where(e => e.Entity is BaseModel && (e.State == EntityState.Added || e.State == EntityState.Modified));
            foreach (var entry in entities)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseModel)entry.Entity).CreatedAt = DateTime.UtcNow;
                }
                else
                {
                    ((BaseModel)entry.Entity).LastUpdatedAt = DateTime.UtcNow;
                }
            }
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateTimestamps(eventData);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateTimestamps(eventData);
            return base.SavingChangesAsync(eventData, result);
        }
    }
}
