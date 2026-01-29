using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PortalGalaxy.DataAccess;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : IdentityDbContext<GalaxyIdentityUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Esto es Cliente API de EF Core
        builder.Entity<GalaxyIdentityUser>(e=> e.ToTable("Usuario")); //AspNetUser
        builder.Entity<IdentityRole>(e => e.ToTable("Rol")); // AspNetRoles
        builder.Entity<IdentityUserRole<string>>(e => e.ToTable("UsuarioRol")); //ApNetUserRoles
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<string>().HaveMaxLength(150);
    }
}