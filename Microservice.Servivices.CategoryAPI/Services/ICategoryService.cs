using Microservice.Servivices.CategoryAPI.Models;
using Microservice.Servivices.CategoryAPI.Models.DTO;

namespace Microservice.Services.CategoryAPI.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<bool> EditCategory(CategoryDTO category);
        Task<bool> AddCategory(CategoryDTO category);
        Task<bool> DeleteCategory(int id);
        Task<Category> GetCategoryById(int id);
    }
}
