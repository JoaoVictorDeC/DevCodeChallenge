
using DevCodeChallenge.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
namespace DevCodeChallenge.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<CoffeeProduct> coffeeProducts { get; set; }
        public DbSet<NasaApod> NasaApods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoffeeProduct>()
                .Property(p => p.CoffeePrice)
                .HasPrecision(18, 2);
        }


    }
}