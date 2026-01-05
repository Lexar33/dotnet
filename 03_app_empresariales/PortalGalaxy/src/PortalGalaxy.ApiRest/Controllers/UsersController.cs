using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using PortalGalaxy.Dto.Request;
using PortalGalaxy.Services.Interfaces;

namespace PortalGalaxy.ApiRest.Controllers
{

    [ApiController] 
    [Route("api/[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService service, ILogger<UsersController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDtoRequest request) 
        {
            var response = await _service.LoginAsync(request);
            _logger.LogInformation("Se inicio sesion desde {RequestID}", HttpContext.Connection.Id);
            return response.Success ? Ok(response): Unauthorized(response);
        }
    }
}
