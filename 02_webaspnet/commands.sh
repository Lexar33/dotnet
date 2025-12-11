dotnet new solution -o ECommerceWeb
mkdir & cd src
dotnet new gitignore
dotnet new webapi -o ECommerceWeb.WebApi
dotnet new blazorwasm -o EcommerceWeb.WebApp

#dotnet new blazor -o name                                  -> Blazor static (static SSR)
#dotnet new blazor -o BlazorApp -int Server                 -> Blazor server via SignalR (dynamic SSR)  

#dotnet new blazor -o EcommerceWeb.WebApp -int WebAssembly  -> Blazor webasssembly (CSR) MODERN
#dotnet new blazorwasm -o EcommerceWeb.WebApp               -> Blazor webasssembly (CSR) OLD

#dotnet new blazor -o name -int auto                        -> SSR , then CSR
#

dotnet run #Folder WebApp

#Añadir paquete
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.10

dotnet restore

dotnet tool install --global dotnet-ef --version 9.0.10
dotnet tool update dotnet-ef --global
dotnet ef
############################################

dotnet ef migrations add PrimeraMigracion
#dotnet ef migrations add ProductosMigration
dotnet ef database update


######################
#docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Pass@123" -p 1433:1433 --name SqlServerGalaxy -d mcr.microsoft.com/mssql/server:2022-latest
#docker exec -it SqlServerGalaxy bash
# /opt/mssql-tools18/bin/sqlcmd -C -S localhost -U sa