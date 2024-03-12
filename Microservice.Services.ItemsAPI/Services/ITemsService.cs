using DataAccess.Data;
using DataAccess.Model;
using Microservice.Services.ItemsAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Services.ItemsAPI.Services
{
    public class ITemsService:IItemService
    {
        private readonly ApplicationDbContext db;
        private readonly ResponseDTO _res;
        public ITemsService(ApplicationDbContext db)
        {
            this.db = db;
            _res = new ResponseDTO();
        }
        public async Task<ResponseDTO> ActivateItem(int id)
        {
            var d = await db.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (d != null)
            {
                d.IsActive = 1;
                await db.SaveChangesAsync();
                _res.IsSuccess = true;
            }
            else
            {
                _res.IsSuccess = false;
            }
            return (_res);
        }

        public async Task<ResponseDTO> AddItem(Item item)
        {
            item.IsActive = 1;
            var d = await db.Items.AddAsync(item);
            await db.SaveChangesAsync();
            _res.IsSuccess = true;
            _res.Message = "Added Item Successfully";
            return (_res);
        }

        public async Task<ResponseDTO> AdminGetItemsBasedOnCategory(int CategoryId)
        {
            var d = await db.Items.Where(x => x.CategoryId == CategoryId).ToListAsync();
            _res.Result = d;
            _res.IsSuccess = true;
            return (_res);
        }

        public async Task<ResponseDTO> ChangeCategory(int itemId, int categoryId)
        {
            var d = await db.Items.FirstOrDefaultAsync(x => x.Id == itemId);
            if (d != null)
            {
                d.CategoryId = categoryId;
                await db.SaveChangesAsync();
                _res.IsSuccess = true;
                _res.Message = "Category chnaged successfully";
            }
            else
            {
                _res.IsSuccess = false;
            }
            return (_res);

        }

        public async Task<ResponseDTO> EditItem(Item item)
        {
            var d = await db.Items.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (d != null)
            {
                d.ProdName = item.ProdName;
                d.Price = item.Price;
                d.Description = item.Description;
                d.CategoryId = item.CategoryId;
                d.ImageUrl = item.ImageUrl;
                d.IsActive = item.IsActive;
                await db.SaveChangesAsync();
                _res.IsSuccess = true;
                _res.Message = "Edit successful";
                return (_res);
            }
            _res.IsSuccess = false;
            return (_res);
        }

        public async Task<ResponseDTO> GetAllItems()
        {
            var d = await db.Items.ToListAsync();
            _res.Result = d;
            _res.IsSuccess = true;
            _res.Message = "All Items";
            return _res;
        }

        public async Task<ResponseDTO> GetItemById(int id)
        {
            var d = await db.Items.FirstOrDefaultAsync(x => x.Id == id);
            _res.Result = d;
            return _res;
        }

        public async Task<ResponseDTO> GetItemsBasedOnCategory(int Categoryid)//show only active Item
        {
            var d = await db.Items.Where(x => x.CategoryId == Categoryid && x.IsActive == 1).ToListAsync();
            _res.Result = d;
            _res.IsSuccess= true;
            _res.Message = "items based on category";
            return _res;
        }

        public async Task<ResponseDTO> InActiveItem(int id)
        {
            var d = await db.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (d != null)
            {
                d.IsActive = 0;
                await db.SaveChangesAsync();
                _res.IsSuccess = true;
                return (_res);
            }
            _res.IsSuccess = false;
            return (_res);
        }

    }
}
