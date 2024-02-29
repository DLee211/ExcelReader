namespace ExcelReader.Model;

public class ExcelData
{
    public string Segment { get; set; }
    public string Country { get; set; }
    public string Product { get; set; }
    public string DiscountBand { get; set; }
    public decimal UnitsSold { get; set; }
    public decimal Manufacturing { get; set; }
    public decimal SalePrice { get; set; }
    public decimal GrossSales { get; set; }
    public decimal Discounts { get; set; }
    public decimal Sales { get; set; }
    public decimal COGS { get; set; }
    public decimal Profit { get; set; }
    public DateTime Date { get; set; }
    public int MonthNumber { get; set; }
    public string MonthName { get; set; }
    public int Year { get; set; }
}