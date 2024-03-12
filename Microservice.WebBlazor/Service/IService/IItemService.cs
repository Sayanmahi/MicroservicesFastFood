using Microservice.WebBlazor.DTO;

namespace Microservice.WebBlazor.Service.IService
{
    public interface IItemService
    {
        Task<ResponseDTO?> AddItem(Item item);
        Task<ResponseDTO?> EditItem(Item item);
        Task<ResponseDTO?> InActiveItem(int id);
        Task<ResponseDTO?> ActivateItem(int id);
        Task<ResponseDTO?> GetItemsBasedOnCategory(int CategoryId);
        Task<ResponseDTO?> AdminGetItemsBasedOnCategory(int CategoryId);
        Task<ResponseDTO?> GetAllItems();
        Task<ResponseDTO?> GetItemById(int id);
        Task<ResponseDTO?> ChangeCategory(int itemId, int categoryId);
    }
}
