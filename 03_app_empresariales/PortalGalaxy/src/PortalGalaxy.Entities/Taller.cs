using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalGalaxy.Entities
{
    public class Taller : EntityBase
    {
        public string Nombre { get; set; } = null!;
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; } = null!;
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;
        public DateOnly FechaInicio { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public SituacionTaller Situacion { get; set; }
        public string? PortadaUrl { get; set; }
        public string? TemarioUrl { get; set; }
        public string? Descripcion { get; set; }

    }
}
