using ExcelReader;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = CreateHostBuilder(args).Build();

using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ExcelDbContext>();
        context.Database.EnsureDeleted(); // Ensure that the database is deleted
        context.Database.EnsureCreated(); // Ensure that the database is created based on the current model
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred while creating the database.");
        Console.WriteLine(ex.Message);
    }
}

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });