using Microservice.WebBlazor.DTO;

namespace Microservice.WebBlazor.Service.IService
{
    public interface ICategoryService
    {
        Task<ResponseDTO?> GetAllCategories(string token);
        Task<ResponseDTO?> EditCategory(CategoryDTO category, string token);
        Task<ResponseDTO?> AddCategory(CategoryDTO category, string token);
        Task<ResponseDTO?> DeleteCategory(int id, string token);
        Task<ResponseDTO?> GetCategoryById(int id, string token);
    }
}
