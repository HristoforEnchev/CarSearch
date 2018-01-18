namespace CarSearch.Data
{
    using CarSearch.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CarSearchDbContext : DbContext
    {
        public CarSearchDbContext(DbContextOptions<CarSearchDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
