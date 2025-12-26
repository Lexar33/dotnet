using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Reflection;

namespace PortalGalaxy.DataAccess;
//Aqui usamos primary constructor de c#12
public class PortalGalaxyDbContext(DbContextOptions<PortalGalaxyDbContext> options)
    : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<string>()
            .HaveMaxLength(100);
        configurationBuilder.Conventions.Remove<SqlServerOnDeleteConvention>();
    }
}
