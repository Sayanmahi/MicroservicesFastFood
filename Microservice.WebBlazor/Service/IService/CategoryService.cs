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
        public Task<ResponseDTO?> AddCategory(CategoryDTO category, string token)
        {
            return _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = category,
                AccessToken=token,
                Url = "https://localhost:7001/api/Category/AddCategory"


            });
        }

        public Task<ResponseDTO?> DeleteCategory(int id, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO?> EditCategory(CategoryDTO category, string token)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
                Data = category,
                AccessToken = token,
                Url = "https://localhost:7001/api/Category/EditCategory"
            });
        }

        public async Task<ResponseDTO?> GetAllCategories(string token)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                AccessToken = token,
                Url = "https://localhost:7001/api/Category/GetAllCategories"
            });
        }

        public async Task<ResponseDTO?> GetCategoryById(int id, string token)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                AccessToken = token,
                Url = "https://localhost:7001/api/Category/GetCategoryById?id=" + id
            });
        }
    }
}
