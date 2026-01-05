using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PortalGalaxy.Common.Configuration;
using PortalGalaxy.DataAccess;
using PortalGalaxy.Dto.Response;
using PortalGalaxy.Dto.Request;
using PortalGalaxy.Services.Interfaces;

namespace PortalGalaxy.Services.Implementations;

public class UserService:IUserService
{
    private readonly UserManager<GalaxyIdentityUser> _userManager;
    private readonly ILogger<UserService> _logger;
    private readonly AppSettings _configuration;
    
    public UserService(IOptions<AppSettings> configuration,
        UserManager<GalaxyIdentityUser> userManager,
        ILogger<UserService> logger)
    {
        _userManager = userManager;
        _logger = logger;
        _configuration = configuration.Value;
    }
    
    public async Task<LoginDtoResponse> LoginAsync(LoginDtoRequest request) {
        var response = new LoginDtoResponse();
        try
        {
            var identity = await _userManager.FindByNameAsync(request.Usuario);

            if (identity == null)
            {
                throw new SecurityException("Usuario no encontrado");
            }

            // Primero revisamos que el usuario no este bloqueado
            if (await _userManager.IsLockedOutAsync(identity))
            {
                throw new SecurityException("Usuario bloqueado por intentos fallidos");
            }

            // Validamos usuario y clave
            if (!await _userManager.CheckPasswordAsync(identity, request.Password))
            {
                response.ErrorMessage = "Clave incorrecta";
                _logger.LogWarning("Intento de acceso fallido para el usuario {usuario}", request.Usuario);
                await _userManager.AccessFailedAsync(identity);

                return response;
            }

            var roles = await _userManager.GetRolesAsync(identity);
            var fechaExpiracion = DateTime.Now.AddHours(1);

            // Vamos a devolver los Claims
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, identity.Id),
                new Claim(ClaimTypes.Name, identity.NombreCompleto),
                new Claim(ClaimTypes.Email, identity.Email!),
            };

            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
            response.Roles = roles.ToList();

            // Generamos el JWT
            var llaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Jwt.SecretKey));
            var credenciales = new SigningCredentials(llaveSimetrica, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(credenciales);

            var payload = new JwtPayload(_configuration.Jwt.Issuer,
                _configuration.Jwt.Audience,
                claims,
                DateTime.Now,
                fechaExpiracion);

            var token = new JwtSecurityToken(header, payload);

            response.Token = new JwtSecurityTokenHandler().WriteToken(token);
            response.NombreCompleto = identity.NombreCompleto;
            response.Success = true;

            _logger.LogInformation("Usuario {usuario} logueado correctamente", request.Usuario);

        }
        catch (SecurityException ex)
        {
            response.ErrorMessage = ex.Message;
            _logger.LogError(ex, "Error al intentar loguear usuario {usuario}", request.Usuario);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al intentar loguear usuario {usuario}", request.Usuario);
            response.ErrorMessage = "Error desconocido";
        }
        
        return response;
    }
    public Task<BaseResponse> RegisterAsync(RegisterUserDto request) {
        throw new NotImplementedException();
    }
}
