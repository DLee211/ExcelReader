# ExcelReader

ExcelReader is a C# project that reads data from an Excel file and writes it to a SQL Server database using Entity Framework Core.

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
