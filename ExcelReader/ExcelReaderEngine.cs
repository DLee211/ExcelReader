using ExcelReader.Model;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace ExcelReader;

public class ExcelReaderEngine
{
    public static List<ExcelData> SetExcelData(string filePath)
    {
        var dataList = new List<ExcelData>();
        
        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            var worksheet = package.Workbook.Worksheets[0];

            int rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++)
            {
                var data = new ExcelData
                {
                    Segment = worksheet.Cells[row, 1].Value.ToString(),
                    Country = worksheet.Cells[row, 2].Value.ToString(),
                    Product = worksheet.Cells[row, 3].Value.ToString(),
                    DiscountBand = worksheet.Cells[row, 4].Value.ToString(),
                    UnitsSold = Convert.ToDecimal(worksheet.Cells[row, 5].Value),
                    Manufacturing = Convert.ToDecimal(worksheet.Cells[row, 6].Value),
                    SalePrice = Convert.ToDecimal(worksheet.Cells[row, 7].Value),
                    GrossSales = Convert.ToDecimal(worksheet.Cells[row, 8].Value),
                    Discounts = Convert.ToDecimal(worksheet.Cells[row, 9].Value),
                    Sales = Convert.ToDecimal(worksheet.Cells[row, 10].Value),
                    COGS = Convert.ToDecimal(worksheet.Cells[row, 11].Value),
                    Profit = Convert.ToDecimal(worksheet.Cells[row, 12].Value),
                    Date = Convert.ToDateTime(worksheet.Cells[row, 13].Value),
                    MonthNumber = Convert.ToInt32(worksheet.Cells[row, 14].Value),
                    MonthName = worksheet.Cells[row, 15].Value.ToString(),
                    Year = Convert.ToInt32(worksheet.Cells[row, 16].Value)
                };
                dataList.Add(data);
            }
        }
        Console.WriteLine("Data read from Excel.");
        return dataList;
    }
    
    public static void WriteToDatabase(List<ExcelData> dataList)
    {
        string connectionString = Environment.GetEnvironmentVariable("DbConnection");
        var optionsBuilder = new DbContextOptionsBuilder<ExcelDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        using (var context = new ExcelDbContext(optionsBuilder.Options))
        {
            context.AddRange(dataList);
            context.SaveChanges();
            Console.WriteLine("Data written to database.");
        }
    }
}