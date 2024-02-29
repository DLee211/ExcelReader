using ExcelReader.Model;
using OfficeOpenXml;

namespace ExcelReader;

public class ExcelReaderEngine
{
    public static void ReadExcelData(string filePath)
    {
        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            var worksheet = package.Workbook.Worksheets[0];

            int rowCount = worksheet.Dimension.Rows;
            int colCount = worksheet.Dimension.Columns;

            for (int row = 1; row <= rowCount; row++)
            {
                for (int col = 1; col <= colCount; col++)
                {
                    Console.WriteLine(worksheet.Cells[row, col].Value);
                }
            }
        }
    }

    public static List<ExcelData> SetExcelData(string filePath)
    {
        var dataList = new List<ExcelData>();
        
        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            var worksheet = package.Workbook.Worksheets[0];

            int rowCount = worksheet.Dimension.Rows;
            int colCount = worksheet.Dimension.Columns;

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
        
        foreach (var data in dataList)
        {
            Console.WriteLine($"Segment: {data.Segment}, Country: {data.Country}, Product: {data.Product}, DiscountBand: {data.DiscountBand}, UnitsSold: {data.UnitsSold}, Manufacturing: {data.Manufacturing}, SalePrice: {data.SalePrice}, GrossSales: {data.GrossSales}, Discounts: {data.Discounts}, Sales: {data.Sales}, COGS: {data.COGS}, Profit: {data.Profit}, Date: {data.Date}, MonthNumber: {data.MonthNumber}, MonthName: {data.MonthName}, Year: {data.Year}");
        }
        
        return dataList;
    }
}