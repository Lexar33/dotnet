using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalGalaxy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalGalaxy.DataAccess.Configurations
{
    internal class TallerConfiguration:IEntityTypeConfiguration<Taller>
    {
        public void Configure(EntityTypeBuilder<Taller> builder)
        {
            builder.ToTable(nameof(Taller));

            builder.Property(p => p.PortadaUrl)
                .IsUnicode(false) // VARCHAR
                .HasMaxLength(500);

            builder.Property(p => p.TemarioUrl)
                .IsUnicode(false) // VARCHAR
                .HasMaxLength(500);

            builder.Property(p => p.Descripcion)
                .HasMaxLength(2500);

            builder.HasQueryFilter(p => p.Estado);

        }
    }
}
