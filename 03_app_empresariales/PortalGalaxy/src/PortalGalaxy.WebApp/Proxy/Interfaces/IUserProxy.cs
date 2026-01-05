using PortalGalaxy.Dto.Request;
using PortalGalaxy.Dto.Response;

namespace PortalGalaxy.WebApp.Proxy.Interfaces
{
    public interface IUserProxy
    {
        Task<LoginDtoResponse> Login(LoginDtoRequest request);
        Task Register(RegisterUserDto request);
        
    }
}
