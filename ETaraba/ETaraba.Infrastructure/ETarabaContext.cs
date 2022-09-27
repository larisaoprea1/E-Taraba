using ETaraba.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace ETaraba.Infrastructure
{
    public class ETarabaContext : IdentityDbContext<User, UserRole, Guid>
    {
        public ETarabaContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<User>()
             .HasOne(a => a.Basket)
             .WithOne(a => a.User)
             .HasForeignKey<Basket>(c => c.UserId);


        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseModel && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseModel)entityEntry.Entity).CreateAt = DateTime.UtcNow;
                }
                else
                {
                    Entry((BaseModel)entityEntry.Entity).Property(p => p.CreateAt).IsModified = false;
                }

                ((BaseModel)entityEntry.Entity).UpdateAt = DateTime.UtcNow;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
