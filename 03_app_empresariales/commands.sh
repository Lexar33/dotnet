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