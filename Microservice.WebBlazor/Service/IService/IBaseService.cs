using Microservice.WebBlazor.DTO;

namespace Microservice.WebBlazor.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO?> SendAsync(RequestDTO requestDTO);
    }
}
