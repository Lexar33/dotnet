using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalGalaxy.Entities
{
    public class Inscripcion : EntityBase
    {
        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; } = null!;
        public int TallerId { get; set; }
        public Taller Taller { get; set; } = null!;
        
        public SituacionTaller Situacion {get; set;}


    }
}
