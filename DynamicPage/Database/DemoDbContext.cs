using DynamicPage.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicPage.Database
{
    public class DemoDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DemoDbContext(DbContextOptions<DemoDbContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).HasMaxLength(100);
            });
        }
    }
}
