using Microservice.WebBlazor.DTO;
using Microservice.WebBlazor.Utility;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Microservice.WebBlazor.Service.IService
{
    public class CartService : ICartService
    {
        private readonly IBaseService _baseService;
        public CartService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDTO> AddToCart(Cart cart)
        {
            return await _baseService.SendCartAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = cart,
                Url = "https://localhost:7003/api/Cart/AddToCart"


            });
        }

        public async Task<ResponseDTO> DeleteItem(int id)
        {
            return await _baseService.SendCartAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.DELETE,
                Url = "https://localhost:7003/api/Cart/DeleteItem?id="+id


            });
        }

        public async Task<ResponseDTO> EditItem(Cart cart)
        {
            return await _baseService.SendCartAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
                Data = cart,
                Url = "https://localhost:7003/api/Cart/EditItem" 


            });
        }

        public async Task<ResponseDTO> GetCartItem(int id)
        {
            return await _baseService.SendCartAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = "https://localhost:7003/api/Cart/GetCartItem?id="+id


            });
        }

        public async Task<ResponseDTO> ItemsInCart(int cid)
        {
            return await _baseService.SendCartAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = "https://localhost:7003/api/Cart/ItemsInCart?cid=" + cid


            });
        }

        public async Task<ResponseDTO> ShowMyCart(int uid)
        {
            return await _baseService.SendCartAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = "https://localhost:7003/api/Cart/ShowMyCart?uid=" + uid


            });
        }
    }
}
