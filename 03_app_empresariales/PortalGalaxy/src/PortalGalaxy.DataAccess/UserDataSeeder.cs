using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PortalGalaxy.Common;

namespace PortalGalaxy.DataAccess;

public static class UserDataSeeder
{
    public static async Task SeedAsync(IServiceProvider service)
    {
        var userManager = service.GetRequiredService<UserManager<GalaxyIdentityUser>>();
        var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
        
        // Creamos los roles
        await roleManager.CreateAsync(new IdentityRole(Constantes.RolAdministrador));
        await roleManager.CreateAsync(new IdentityRole(Constantes.RolAlumno));
        
        // Creamos el usuario administrador
        var adminUser = new GalaxyIdentityUser()
        {
            NombreCompleto = "Administrador del Sistema",
            UserName = "admin",
            Email = "admin@gmail.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            PhoneNumber = "0000000000"
        };
        
        var result = await userManager.CreateAsync(adminUser, "Admin123!");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, Constantes.RolAdministrador);
        }

    }
    
}