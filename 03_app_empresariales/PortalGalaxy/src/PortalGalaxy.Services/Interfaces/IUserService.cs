using PortalGalaxy.Dto;
using PortalGalaxy.Dto.Request;
using PortalGalaxy.Dto.Response;

namespace PortalGalaxy.Services.Interfaces
{
    public interface IUserService
    {
        Task<LoginDtoResponse> LoginAsync(LoginDtoRequest request);
        Task<BaseResponse> RegisterAsync(RegisterUserDto request);
    }
}
