using System.ComponentModel.DataAnnotations;

namespace PortalGalaxy.Dto.Request;

public class LoginDtoRequest
{
    [Display(Name = "Nombre de Usuario")]
    [Required]
    public string Usuario { get; set; } = null!;
    
    [Display(Name = "Contraseña")]
    [Required]
    public string Password { get; set; } = null!;
}
