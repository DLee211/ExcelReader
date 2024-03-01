using ExcelReader;
using ExcelReader.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

string filePath = "C:\\Users\\dnll4\\RiderProjects\\ExcelReader\\ExcelReader\\Financial Sample.xlsx";


var host = CreateHostBuilder(args).Build();
using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    using (var context = services.GetRequiredService<ExcelDbContext>())
    {
        if (context.Database.CanConnect())
        {
            Console.WriteLine("Database connected");
            context.Database.EnsureDeleted();
            Console.WriteLine("Former Database deleted");
        }

        context.Database.EnsureCreated();
        Console.WriteLine("Database created");
        List<ExcelData> dataList = ExcelReaderEngine.SetExcelData(filePath);
        ExcelReaderEngine.WriteToDatabase(dataList);
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