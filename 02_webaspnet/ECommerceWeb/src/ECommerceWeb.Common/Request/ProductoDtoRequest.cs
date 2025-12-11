using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWeb.Common.Request
{
    public class ProductoDtoRequest
    {
        public int CategoriaId { get; set; }
        public int MarcaId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public float PrecioUnitario { get; set; }
        public string? UrlImagen { get; set; }
    }
}
