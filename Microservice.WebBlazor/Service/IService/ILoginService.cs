using Microservice.WebBlazor.DTO;

namespace Microservice.WebBlazor.Service.IService
{
    public interface ILoginService
    {
        Task<ResponseDTO?> LoginUser(LoginDTO l);
        Task<ResponseDTO?> LoginAdmin(LoginDTO l);
        Task<ResponseDTO?> Register(UserDTO user);
    }
}
