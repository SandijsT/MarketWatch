using Microsoft.EntityFrameworkCore;
using SSWebScraper.Models;
using SSWebScraper.ScraperService;

namespace SSWebScraper.DB
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
        public DbSet<VehicleObject>? VehicleMatrices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
