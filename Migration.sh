
//Product Migration
dotnet ef migrations add ProductsAddColumnDescription
dotnet ef database update

//Sales Migration
dotnet ef migrations add SalesAddDateDefault
dotnet ef database update
