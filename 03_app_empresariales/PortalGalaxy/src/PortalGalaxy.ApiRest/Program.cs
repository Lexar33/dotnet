using Microsoft.EntityFrameworkCore;
using PortalGalaxy.DataAccess;
using PortalGalaxy.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<PortalGalaxyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/api/categorias", (PortalGalaxyDbContext context) =>
{
    var categorias = context.Set<Categoria>().ToList();
    return Results.Ok(categorias);
});

app.MapGet("/api/categoriassl", (PortalGalaxyDbContext context) =>
{
    var connection = context.Database.GetDbConnection();
    connection.Open();
    using (var command = connection.CreateCommand())
    {
        command.CommandText = "SELECT * FROM Categoria";
        var reader = command.ExecuteReader();
        var categorias = new List<Categoria>();
        while (reader.Read())
        {
            categorias.Add(new Categoria
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1)
            });
            reader.Close();
            connection.Close();
        }
    }
});

app.Run();

