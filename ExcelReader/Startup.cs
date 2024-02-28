using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelReader;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Other service configurations

        services.AddDbContext<ExcelDbContext>(options =>
            options.UseSqlServer(Environment.GetEnvironmentVariable("DbConnection")));
    }
}