using Microsoft.Extensions.Primitives;

namespace WebApiSesion02
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Cargo { get; set; } = "Programador";
        public int Edad { get; set; } = 0;
        public decimal Salario{ get; set; }
        
    }
}
