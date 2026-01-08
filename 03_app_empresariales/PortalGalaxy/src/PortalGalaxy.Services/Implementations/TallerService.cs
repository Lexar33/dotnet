using AutoMapper;
using Microsoft.Extensions.Logging;
using PortalGalaxy.Dto.Request;
using PortalGalaxy.Dto.Response;
using PortalGalaxy.Dto.Utils;
using PortalGalaxy.Repositories.Interfaces;
using PortalGalaxy.Services.Interfaces;

namespace PortalGalaxy.Services.Implementations;

public class TallerService : ITallerService
{
    private readonly ITallerRepository _tallerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<TallerService> _logger;

    public TallerService(ITallerRepository tallerRepository, ILogger<TallerService> logger, IMapper mapper)
    {
        _tallerRepository = tallerRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<PaginationResponse<TallerDtoResponse>> ListarAsync(BusquedaTallerRequest request)
    {
        var response = new PaginationResponse<TallerDtoResponse>();
        try
        {
            var tupla = await _tallerRepository.ListarTalleresAsync(request.Nombre, request.Categoria, request.Situacion,
                request.PageNumber, request.PageSize);
            
            response.Data = _mapper.Map<ICollection<TallerDtoResponse>>(tupla.Collection);
            response.TotalPages = Helper.GetTotalPages(tupla.Total, request.PageSize);
            response.TotalCount = tupla.Total;
            response.Success = true;
            
            
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al listar talleres";
            _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }
}