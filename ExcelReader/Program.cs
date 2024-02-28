using ExcelReader;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var host = CreateHostBuilder(args).Build();
using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    using (var context = services.GetRequiredService<ExcelDbContext>())
    {
        if (context.Database.CanConnect())
        {
            context.Database.EnsureDeleted();
        }

        context.Database.EnsureCreated();
        Console.WriteLine("Database created");
    }

    host.Run();
}


static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        })
        .ConfigureServices((_, services) =>
            services.AddDbContext<ExcelDbContext>());