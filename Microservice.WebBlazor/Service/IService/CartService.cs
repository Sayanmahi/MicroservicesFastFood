using Microservice.WebBlazor.DTO;
using Microservice.WebBlazor.Utility;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Microservice.WebBlazor.Service.IService
{
    public class CartService : ICartService
    {
        private readonly IBaseService _baseService;
        private readonly ITokenService tok;
        public CartService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDTO> AddToCart(Cart cart, string token)
        {
            return await _baseService.SendCartAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = cart,
                AccessToken = token,
                Url = "https://localhost:7003/api/Cart/AddToCart"


            });
        }
        public async Task<ResponseDTO> ShowImage(string token)
        {
            return await _baseService.SendCartAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                AccessToken = token,
                Url = "https://localhost:7003/api/Cart/GetImage"


            });
        }
        public async Task<ResponseDTO> AddImage(ImageFile image, string token)
        {
            return await _baseService.SendCartAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = image,
                AccessToken = token,
                Url = "https://localhost:7003/api/Cart/AddImage"


            });
        }

        public async Task<ResponseDTO> DeleteItem(int id, string token)
        {
            return await _baseService.SendCartAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.DELETE,
                AccessToken = token,
                Url = "https://localhost:7003/api/Cart/DeleteItem?id="+id


            });
        }

        public async Task<ResponseDTO> EditItem(Cart cart, string token)
        {
            return await _baseService.SendCartAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
                Data = cart,
                AccessToken = token,
                Url = "https://localhost:7003/api/Cart/EditItem" 


            });
        }

        public async Task<ResponseDTO> GetCartItem(int id, string token)
        {
            return await _baseService.SendCartAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                AccessToken = token,
                Url = "https://localhost:7003/api/Cart/GetCartItem?id="+id


            });
        }

        public async Task<ResponseDTO> ItemsInCart(int cid, string token)
        {
            return await _baseService.SendCartAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                AccessToken = token,
                Url = "https://localhost:7003/api/Cart/ItemsInCart?cid=" + cid


            });
        }

        public async Task<ResponseDTO> ShowMyCart(int uid,string token)
        {

            return await _baseService.SendCartAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                AccessToken=token,
                Url = "https://localhost:7003/api/Cart/ShowMyCart?uid=" + uid


            });
        }

        public async Task<ResponseDTO> ShowImageBytes(string token)
        {
            return await _baseService.SendCartAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                AccessToken = token,
                Url = "https://localhost:7003/api/Cart/GetImageFromBytes"


            });
            
        }
    }
}
