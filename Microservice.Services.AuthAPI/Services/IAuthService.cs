
using Microservice.Services.AuthAPI.Model.DTO;

namespace Microservice.Services.AuthAPI.Services
{
    public interface IAuthService
    {
        Task<ResponseDTO> LoginUser(LoginDTO l);
        Task<ResponseDTO> LoginAdmin(LoginDTO l);
        Task<ResponseDTO> Register(UserDTO user);
    }
}
