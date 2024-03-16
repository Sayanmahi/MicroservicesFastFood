using Microservice.WebBlazor.DTO;

namespace Microservice.WebBlazor.Service.IService
{
    public interface IItemService
    {
        Task<ResponseDTO?> AddItem(Item item,string token);
        Task<ResponseDTO?> EditItem(Item item,string token);
        Task<ResponseDTO?> InActiveItem(int id,string token);
        Task<ResponseDTO?> ActivateItem(int id, string token);
        Task<ResponseDTO?> GetItemsBasedOnCategory(int CategoryId,string token);
        Task<ResponseDTO?> AdminGetItemsBasedOnCategory(int CategoryId, string token);
        Task<ResponseDTO?> GetAllItems(string token);
        Task<ResponseDTO?> GetItemById(int id, string token);
        Task<ResponseDTO?> ChangeCategory(int itemId, int categoryId,string token);
    }
}
