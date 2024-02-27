using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExcelReader;

public class ExcelDbContext : DbContext
{
    
    private readonly IConfiguration _configuration;
    
    public ExcelDbContext(DbContextOptions<ExcelDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = _configuration.GetConnectionString("DbConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }

    
}