using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PortalGalaxy.DataAccess;
using PortalGalaxy.Entities;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<PortalGalaxyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        c => c.MigrationsHistoryTable("SecurityMigrations"));
    
    
});

//Configuramos ASP.NET Identity Core
builder.Services.AddIdentity<GalaxyIdentityUser, IdentityRole>(policies => {

    policies.Password.RequireDigit = false;
    policies.Password.RequiredLength = 8;
    policies.Password.RequireLowercase = true;
    policies.Password.RequireNonAlphanumeric = false;
    policies.Password.RequireUppercase = false;

    policies.User.RequireUniqueEmail = true;

    //Politicas de bloque de cuentas
    policies.Lockout.AllowedForNewUsers = true;
    policies.Lockout.MaxFailedAccessAttempts = 3;
    policies.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
}).AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

//Configuramos el contexto de seugridad del API
builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme= JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    var secretKey = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]
                                           ?? throw new InvalidOperationException("No se ha configurado la clave secreta JWT"));
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(secretKey)
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/api/categorias", (PortalGalaxyDbContext context) =>
{
    var categorias = context.Set<Categoria>().ToList();
    return Results.Ok(categorias);
});

app.MapGet("/api/categoriass", (PortalGalaxyDbContext context) =>
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

