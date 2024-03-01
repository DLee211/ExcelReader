# ExcelReader

This project, named "ExcelReader", is a C# application that reads data from an Excel file and writes it to a SQL Server database using Entity Framework Core. The data read from the Excel file is structured according to a specific model, ExcelData, which includes various properties such as Segment, Country, Product, DiscountBand, UnitsSold, Manufacturing, SalePrice, GrossSales, Discounts, Sales, COGS, Profit, Date, MonthNumber, MonthName, and Year.  The application uses the EPPlus library to read the Excel file. The data is then mapped to the ExcelData model and added to a list. This list of data is then written to a SQL Server database using Entity Framework Core.  The application is configured using a host builder, which sets up the app configuration and services. The database context, ExcelDbContext, is registered as a service and used to interact with the database.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- .NET 8.0
- SQL Server

### Installing

1. Clone the repository: git clone https://github.com/DLee211/ExcelReader.git
2. Navigate to the project directory: cd ExcelReader
3. Restore the .NET packages: dotnet restore
4. Build the project: dotnet build
5. Run the project: dotnet run

## Usage

1. Update the `filePath` variable in `Program.cs` with the path to your Excel file.
2. Run the project. The program will read data from the Excel file and write it to the database.

## Built With

- **C#**: The main programming language used.
- **.NET 8.0**: The framework used.
- **Entity Framework Core**: The Object-Relational Mapping (ORM) framework used.
- **SQL Server**: The database system used.
- **EPPlus**: A .NET library to read and write Excel 2007/2010 files using the Open Office Xml format (xlsx).
- **JetBrains Rider 2023.3.2**: The Integrated Development Environment (IDE) used.
