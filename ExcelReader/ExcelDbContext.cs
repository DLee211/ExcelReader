using ExcelReader.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelReader
{
    public class ExcelDbContext : DbContext
    {
        
        public DbSet<ExcelData> ExcelData { get; set; }
        
        public ExcelDbContext(DbContextOptions<ExcelDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Environment.GetEnvironmentVariable("DbConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            // Get the connection string from your configuration
            string connectionString =Environment.GetEnvironmentVariable("DbConnection");

            // Add ExcelDbContext to the DI container
            services.AddDbContext<ExcelDbContext>(options => options.UseSqlServer(connectionString));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExcelData>()
                .HasKey(c => new { c.Segment, c.Country, c.Product, c.Date, c.Profit });
            
            modelBuilder.Entity<ExcelData>()
                .Property(e => e.COGS)
                .HasPrecision(20, 5);

            modelBuilder.Entity<ExcelData>()
                .Property(e => e.Discounts)
                .HasPrecision(20, 5);

            modelBuilder.Entity<ExcelData>()
                .Property(e => e.GrossSales)
                .HasPrecision(20, 5);

            modelBuilder.Entity<ExcelData>()
                .Property(e => e.Manufacturing)
                .HasPrecision(20, 5);

            modelBuilder.Entity<ExcelData>()
                .Property(e => e.Profit)
                .HasPrecision(20, 5);

            modelBuilder.Entity<ExcelData>()
                .Property(e => e.SalePrice)
                .HasPrecision(20, 5);

            modelBuilder.Entity<ExcelData>()
                .Property(e => e.Sales)
                .HasPrecision(20, 5);

            modelBuilder.Entity<ExcelData>()
                .Property(e => e.UnitsSold)
                .HasPrecision(20, 5);
        }
        
    }
}