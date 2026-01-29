using System.Globalization;
using WebApiSesion02;
using Bogus;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "WebApiSesion02 v1"));
}

app.UseHttpsRedirection(); // Forzar a que se encuentra en HTTP redirigir a HTTPS


app.MapPost("/saludar", (Persona request) =>
{
    int salarioMinimo = 2500;
    if (request.Salario >0 && request.Salario < salarioMinimo)
    {
        request.Cargo = "Programado Junior";
    }
    else if (request.Salario >= 2500)
    {
        request.Cargo = "Programado Seminisenior";
    }
    else if (request.Salario >= 3500)
    {
        request.Cargo = "Programador Senior";
    }
    else
    {
        request.Cargo = "Project Manager";
    }

    var fechaNacimiento = DateTime.Today.AddYears(request.Edad * -1);
    
    

    var culture = new CultureInfo("es-ES");
    System.Threading.Thread.CurrentThread.CurrentCulture = culture;
    
    return Results.Ok(new RespuestaComun
    {
        Mensaje =
            $"Hola {request.Nombre}, bienvenido a tu primer WebApi en .net 9. Tu edad es de {request.Edad} ganando un total de {request.Salario:C2} y" +
            $" naciste el {fechaNacimiento:G} - {fechaNacimiento:dd-MMMM-yyyy}"
    });
});

app.MapPost("/CrearPersonaSwitch", (Persona request) =>
{
    var retorno = new RespuestaComun();
    switch (request.Edad)
    {
        case >= 18 and <= 24:
            retorno.Mensaje= "Apernas comienzas la edad adulta";
            break;
        case 25 and <= 64:
            retorno.Mensaje = "Ya eres un adulto";
            break;    
        case 65:
            retorno.Mensaje = "Ya es hora de jubilarte";
            break;
        default:
            retorno.Mensaje = "Tu edad no la reconozco pero espero que estes bien";
            break;
    }

    return Results.Ok(retorno);
    
});

app.MapPost("/buclefor-objetos",  (int numero) =>
{
    var lista= new List<Persona>();
    for (int i = 0; i <=  numero; i++)
    {
        var mensaje = $"Persona numero : {i}";
        //lista.Add(new Persona { Id = i,Nombre = mensaje,Salario = 1500*i,Edad = 2*i });
        Persona item= new() { Id = i,Nombre = mensaje,Salario = 1500*i,Edad = 2*i };
        lista.Add(item);
        if (i == 4)
        {
            item.Cargo = "Project Manager";
        }
    }
    return Results.Ok(lista);
});

app.MapPost("/buble-foreach", () =>
{

    var faker = new Faker<Persona>()
        .RuleFor(p=>p.Id,f=> f.IndexFaker)
        .RuleFor(p => p.Nombre, f => f.Name.FirstName())
        .RuleFor(p => p.Cargo, f => f.Person.Website)
        .RuleFor(p => p.Edad, f => DateTime.Today.Year - f.Person.DateOfBirth.Year)
        .RuleFor(p => p.Salario, f => f.Finance.Amount());

    var lista = new List<Persona>();
    for (int i=0;i<100;i++){
        lista.Add(faker.Generate());
    }
    
    //foreach(Persona item in lista)
    foreach (var item in lista.OrderBy(p => p.Nombre))
    {
      Console.WriteLine(item.Nombre);  
    }

    return Results.Ok(lista);
});



app.Run();