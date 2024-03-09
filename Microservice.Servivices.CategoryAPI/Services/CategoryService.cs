using Microservice.Services.CategoryAPI.Data;
using Microservice.Services.CategoryAPI.Models.DTO;
using Microservice.Servivices.CategoryAPI.Models;
using Microservice.Servivices.CategoryAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Services.CategoryAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext db;
        private readonly ResponseDTO _res;

        public CategoryService(AppDbContext db)
        {
            this.db = db;
            _res = new ResponseDTO();
        }
        public async Task<ResponseDTO> AddCategory(CategoryDTO category)
        {
            Category b = new Category()
            {
                Name = category.Name,
                ImageUrl = category.ImageUrl
            };
            var d = await db.Categories.AddAsync(b);
            await db.SaveChangesAsync();
            _res.IsSuccess = true;
            return _res;
        }

        public Task<ResponseDTO> DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO> EditCategory(CategoryDTO category)
        {
            var d = await db.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
            if (d != null)
            {
                d.Name = category.Name;
                d.ImageUrl = category.ImageUrl;
                await db.SaveChangesAsync();
                _res.IsSuccess = true;
                
            }
            else
            {
                _res.IsSuccess = false;
            }
            return (_res);
        }

        public async Task<ResponseDTO> GetAllCategories()
        {
            var d = await db.Categories.ToListAsync();
            _res.Result = d;
            _res.IsSuccess = true;
            return _res;
        }

        public async Task<ResponseDTO> GetCategoryById(int id)
        {
            var d = await db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (d!=null)
            {
                _res.Result = d;
                _res.IsSuccess = true;
                _res.Message = "Successfully retrieved";
            }
            else
            {
                _res.IsSuccess= false;
            }
            
            return (_res);
        }
    }
}
