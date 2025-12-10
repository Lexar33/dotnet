#dotnet new Blazor -o MiApp
#dotnet run 
#dotnet new --helpw
#Construye el proyecto y ejecuta
dotnet build
dotnet run
#Nueva solucion
dotnet new solution -o ECommerceWeb
#dotnet new sln --name Fundamentos
###############################
#PROYECTO DE LINEA DE COMANDOS
#Nuevo proyecto
dotnet new console -n sesion05 -o src/sesion05 
#Se añade el proyecto a la solucion
dotnet sln add .\src\sesion05\sesion05.csproj
#Eliminar proyecto
dotnet sln remove .\src\sesion05\sesion05.csproj
###############################
#PROYECTO WPF
dotnet new wpf --name MyWpfApp -lang "C#"
################################
#PROYECTO WEBAPI
dotnet new webapi -o PedidosApiRest