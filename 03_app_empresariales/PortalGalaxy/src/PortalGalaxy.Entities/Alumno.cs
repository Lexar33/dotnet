using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalGalaxy.Entities
{
    public  class Alumno : EntityBase
    {
        public string NombreCompleto { get; set; } = null!;
        public string NroDocumento { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string? Telefono {get; set;}= null!;
        public string Departamento { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Distrito { get; set; } = null!;
        public DateTime fechaInscripcion { get; set; }

        // Crear propiedad de navegacion
        public virtual HashSet<Inscripcion> Inscripciones { get; set; } = new();
    }
}
