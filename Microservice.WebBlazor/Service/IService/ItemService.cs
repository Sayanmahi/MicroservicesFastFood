using Microservice.WebBlazor.DTO;
using Microservice.WebBlazor.Utility;
using static System.Net.WebRequestMethods;

namespace Microservice.WebBlazor.Service.IService
{
    public class ItemService : IItemService
    {
        private readonly IBaseService _baseService;
        public ItemService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDTO> ActivateItem(int id,string token)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
                AccessToken=token,
                Url = "https://localhost:7279/api/Items/ActivateItem?itemid=" + id


            }) ;
        }

        public async Task<ResponseDTO> AddItem(Item item,string token)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = item,
                AccessToken=token,
                Url = "https://localhost:7279/api/Items/AddItem"
            });
        }

        public Task<ResponseDTO> AdminGetItemsBasedOnCategory(int CategoryId,string token)
        {
            return _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                AccessToken = token,
                Url = "https://localhost:7279/api/Items/GetItemsBasedOnCategory?catid=" + CategoryId


            });
        }

        public Task<ResponseDTO> ChangeCategory(int itemId, int categoryId,string token)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> EditItem(Item item,string token)
        {
            return _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
                Data = item,
                AccessToken = token,
                Url = "https://localhost:7279/api/Items/EditItem"
            });
        }

        public Task<ResponseDTO> GetAllItems(string token)
        {
            return _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                AccessToken=token,
                Url = "https://localhost:7279/api/Items/GetAllItems"
            });
        }

        public Task<ResponseDTO> GetItemById(int id,string token)
        {
            return _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                AccessToken=token,
                Url = "https://localhost:7279/api/Items/GetItemById?id=" + id
            });
        }

        public Task<ResponseDTO> GetItemsBasedOnCategory(int CategoryId,string token)
        {
            return _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                AccessToken=token,
                Url = "https://localhost:7279/api/Items/GetItemsBasedOnCategory?catid=" + CategoryId
            });
        }

        public Task<ResponseDTO> InActiveItem(int id,string token)
        {
            return _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
                AccessToken=token,
                Url = "https://localhost:7279/api/Items/InActiveItem?id=1" +id
            });
        }
    }
}
