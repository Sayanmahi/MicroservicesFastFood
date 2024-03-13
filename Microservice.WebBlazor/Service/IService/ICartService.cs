using Microservice.WebBlazor.DTO;

namespace Microservice.WebBlazor.Service.IService
{
    public interface ICartService
    {
        Task<ResponseDTO> ShowMyCart(int uid);
        Task<ResponseDTO> GetCartItem(int id);
        Task<ResponseDTO> AddToCart(Cart cart);
        Task<ResponseDTO> EditItem(Cart cart);
        Task<ResponseDTO> DeleteItem(int id);
        Task<ResponseDTO> ItemsInCart(int cid);
    }
}
