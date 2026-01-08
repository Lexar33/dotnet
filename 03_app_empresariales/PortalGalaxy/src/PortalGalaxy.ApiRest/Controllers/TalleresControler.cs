using Microsoft.AspNetCore.Mvc;
using PortalGalaxy.Dto.Request;
using PortalGalaxy.Services.Interfaces;

namespace PortalGalaxy.ApiRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TalleresControler : ControllerBase
{
    private readonly ITallerService _service;
    
    public TalleresControler(ITallerService service)
    {
        _service = service;
        
    }

    [HttpGet]
    public async Task<IActionResult> ListarTalleres([FromQuery] BusquedaTallerRequest request)
    {
        var response = await _service.ListarAsync(request);
        return Ok(response);
    }


}