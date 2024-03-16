using Microservice.WebBlazor.DTO;

namespace Microservice.WebBlazor.Service.IService
{
    public interface ICartService
    {
        Task<ResponseDTO> ShowMyCart(int uid,string token);
        Task<ResponseDTO> GetCartItem(int id, string token);
        Task<ResponseDTO> AddToCart(Cart cart, string token);
        Task<ResponseDTO> EditItem(Cart cart, string token);
        Task<ResponseDTO> DeleteItem(int id, string token);
        Task<ResponseDTO> ItemsInCart(int cid, string token);
    }
}
