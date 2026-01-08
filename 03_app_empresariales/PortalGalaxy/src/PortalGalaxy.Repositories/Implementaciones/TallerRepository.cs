using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using PortalGalaxy.DataAccess;
using PortalGalaxy.Entities;
using PortalGalaxy.Entities.Infos;
using PortalGalaxy.Repositories.Interfaces;

namespace PortalGalaxy.Repositories.Implementaciones
{
    public class TallerRepository : RepositoryBase<Taller>, ITallerRepository
    {
        public TallerRepository(PortalGalaxyDbContext context) : base(context)
        {
        }

        public async Task<(ICollection<TallerInfo> Collection, int Total)> ListarTalleresAsync(string? nombre, int? categoriaId, int? situacion, int pagina, int filas)
        {
            var tupla = await ListAsync(predicate: p => p.Nombre.Contains(nombre ?? string.Empty) && (categoriaId == null || p.CategoriaId == categoriaId)
            && ( situacion == null || p.Situacion== (SituacionTaller)situacion)
            && p.Estado,
                selector: p=>new TallerInfo
                {
                    Id= p.Id,
                    Nombre= p.Nombre,
                    Categoria= p.Categoria.Nombre,
                    Instructor = p.Instructor.Nombres,
                    Fecha= p.FechaInicio,
                    Situacion = p.Situacion.ToString().Replace("_"," ")
                },
                orderBy:x=>x.Id,
                relations: "Categoria,Instructor",
                pageNumber: pagina,
                pageSize:filas);
            return tupla;
        }
    }
}