using Microservice.WebBlazor.DTO;
using Microservice.WebBlazor.Utility;

namespace Microservice.WebBlazor.Service.IService
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseService _baseService;
        public CategoryService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public Task<ResponseDTO?> AddCategory(CategoryDTO category)
        {
            return _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = category,
                Url = SD.CategoryAPIBase + "/api/Category/AddCategory"


            });
        }

        public Task<ResponseDTO?> DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO?> EditCategory(CategoryDTO category)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
                Data = category,
                Url = SD.CategoryAPIBase + "/api/Category/EditCategory"
            });
        }

        public async Task<ResponseDTO?> GetAllCategories()
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CategoryAPIBase + "/api/Category/GetAllCategories"
            });
        }

        public async Task<ResponseDTO?> GetCategoryById(int id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CategoryAPIBase + "/api/Category/GetCategoryById?id=" + id
            });
        }
    }
}
