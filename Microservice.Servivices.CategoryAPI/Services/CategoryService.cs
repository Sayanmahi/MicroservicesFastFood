using Microservice.Services.CategoryAPI.Data;
using Microservice.Servivices.CategoryAPI.Models;
using Microservice.Servivices.CategoryAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Services.CategoryAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext db;
        public CategoryService(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> AddCategory(CategoryDTO category)
        {
            Category b = new Category()
            {
                Name = category.Name,
                ImageUrl = category.ImageUrl
            };
            var d = await db.Categories.AddAsync(b);
            await db.SaveChangesAsync();
            return true;
        }

        public Task<bool> DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditCategory(CategoryDTO category)
        {
            var d = await db.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
            if (d != null)
            {
                d.Name = category.Name;
                d.ImageUrl = category.ImageUrl;
                await db.SaveChangesAsync();
                return (true);
            }
            return (false);
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var d = await db.Categories.ToListAsync();
            return d;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var d = await db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            return (d);
        }
    }
}
