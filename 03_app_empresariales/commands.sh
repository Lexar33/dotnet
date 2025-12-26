dotnet --info 
dotnet new solution -o PortalGalaxy
dotnet new gitignore
dotnet new webapi -o PortalGalaxy.ApiRest
dotnet new blazorwasm -o PortalGalaxy.WebApp

dotnet new classlib -o PortalGalaxy.DataAccess
dotnet new classlib -o PortalGalaxy.Services
dotnet new classlib -o PortalGalaxy.Entities
dotnet new classlib -o PortalGalaxy.Repositories
dotnet new classlib -o PortalGalaxy.Dto
dotnet new classlib -o PortalGalaxy.Common
dotnet new xunit -o PortalGalaxy.UnitTests
#Migracion
dotnet dotnet-ef migrations add InitialMigration --project src/PortalGalaxy.DataAccess/PortalGalaxy.DataAccess.csproj --startup-project src/PortalGalaxy.ApiRest/PortalGalaxy.ApiRest.csproj 
dotnet ef database update --project src/PortalGalaxy.DataAccess/PortalGalaxy.DataAccess.csproj --startup-project src/PortalGalaxy.ApiRest/PortalGalaxy.ApiRest.csproj 
dotnet dotnet-ef migrations add InitialSecurityMIgration --project src/PortalGalaxy.DataAccess/PortalGalaxy.DataAccess.csproj --startup-project src/PortalGalaxy.ApiRest/PortalGalaxy.ApiRest.csproj  --context ApplicationDbContext
dotnet dotnet-ef database update --project src/PortalGalaxy.DataAccess/PortalGalaxy.DataAccess.csproj --startup-project src/PortalGalaxy.ApiRest/PortalGalaxy.ApiRest.csproj  --context ApplicationDbContext

#Manifiesto #paquetes locales
dotnet new tool-manifest
dotnet tool install dotnet-ef --local --version 9.0.11



#"Gemini the best ia of all the times because it helps a lot" - Base 64 encoding - Jwt Secret key