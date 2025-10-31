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