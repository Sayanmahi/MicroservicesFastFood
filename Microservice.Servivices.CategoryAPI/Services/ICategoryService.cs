using Microservice.Services.CategoryAPI.Models.DTO;
using Microservice.Servivices.CategoryAPI.Models;
using Microservice.Servivices.CategoryAPI.Models.DTO;

namespace Microservice.Services.CategoryAPI.Services
{
    public interface ICategoryService
    {
        Task<ResponseDTO> GetAllCategories();
        Task<ResponseDTO> EditCategory(CategoryDTO category);
        Task<ResponseDTO> AddCategory(CategoryDTO category);
        Task<ResponseDTO> DeleteCategory(int id);
        Task<ResponseDTO> GetCategoryById(int id);
    }
}
