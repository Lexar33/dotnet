using PortalGalaxy.Dto.Request;
using PortalGalaxy.Dto.Response;

namespace PortalGalaxy.Services.Interfaces;

public interface ITallerService
{
    Task<PaginationResponse<TallerDtoResponse>> ListarAsync(BusquedaTallerRequest request);
}