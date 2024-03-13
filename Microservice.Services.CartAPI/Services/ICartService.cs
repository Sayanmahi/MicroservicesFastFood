using DataAccess.Model;
using Microservice.Services.CartAPI.Model.DTO;

namespace Microservice.Services.CartAPI.Services
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
