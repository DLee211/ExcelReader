using ExcelReader.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelReader
{
    public class ExcelDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        
        public DbSet<ExcelData> ExcelData { get; set; }
        
        public ExcelDbContext(DbContextOptions<ExcelDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
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
                .HasNoKey();
            
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