using PortalGalaxy.Dto.Request;
using PortalGalaxy.Dto.Response;
using PortalGalaxy.WebApp.Proxy.Interfaces;

namespace PortalGalaxy.WebApp.Proxy.Services
{
    public class UserProxy : RestBase,IUserProxy
    {
        public UserProxy(HttpClient httpClient) : base("api/Users", httpClient) {
            
        }
        /*
        public UserProxy(string baseUrl, HttpClient httpClient) : base(baseUrl, httpClient) {
        }
        */
        public async Task<LoginDtoResponse> Login(LoginDtoRequest request) {
            var response= await SendAsync <LoginDtoRequest,LoginDtoResponse>(request,HttpMethod.Post,"login");
            return response;
        }
        public async Task Register(RegisterUserDto request) {
            var response = await SendAsync<RegisterUserDto, BaseResponse>(request, HttpMethod.Post, "register");
            if(!response.Success)
                throw new ApplicationException(response.ErrorMessage);
            
        }
    }
}
