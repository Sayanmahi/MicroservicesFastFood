using Microservice.WebBlazor.DTO;

namespace Microservice.WebBlazor.Service.IService
{
    public interface ICategoryService
    {
        Task<ResponseDTO?> GetAllCategories();
        Task<ResponseDTO?> EditCategory(CategoryDTO category);
        Task<ResponseDTO?> AddCategory(CategoryDTO category);
        Task<ResponseDTO?> DeleteCategory(int id);
        Task<ResponseDTO?> GetCategoryById(int id);
    }
}
