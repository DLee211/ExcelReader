using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelReader
{
    public class ExcelDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

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
    }
}