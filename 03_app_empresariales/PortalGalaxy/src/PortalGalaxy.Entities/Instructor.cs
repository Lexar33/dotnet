using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalGalaxy.Entities
{
    public class Instructor : EntityBase
    {
        public string NroDocumento { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; } = null!;
    }
}
