using DataAccess.Data;
using DataAccess.Model;
using Microservice.Services.CartAPI.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Services.CartAPI.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext db;
        private readonly ResponseDTO res;
        public CartService(ApplicationDbContext db)
        {
            this.db = db;
            res= new ResponseDTO();
        }
        public async Task<ResponseDTO> AddToCart(Cart cart)
        {
            var itemPrice = await db.Items.FindAsync(cart.ItemId);
            cart.Price = cart.Qty * itemPrice.Price;
            var d = await db.Carts.AddAsync(cart);
            await db.SaveChangesAsync();
            res.IsSuccess = true;
            res.Message = "Item added Successfully";
            return (res);
        }

        public async Task<ResponseDTO> DeleteItem(int id)
        {
            var d = await db.Carts.FirstOrDefaultAsync(x => x.Id == id);
            if (d != null)
            {
                db.Carts.Remove(d);
                await db.SaveChangesAsync();
                res.IsSuccess = true;
                res.Message = "Item Deleted sucessfully";
               
            }
            else
            {
                res.IsSuccess = false;
            }
            return (res);
        }

        public async Task<ResponseDTO> EditItem(Cart cart)
        {
            var d = await db.Carts.FindAsync(cart.Id);
            if (d != null)
            {
                var dd = await db.Items.FirstOrDefaultAsync(x => x.Id == d.ItemId);
                d.Qty = cart.Qty;
                d.Price = cart.Qty * dd.Price;
                await db.SaveChangesAsync();
                res.IsSuccess = true;
                res.Message = "Edit Successful";
               
            }
            else
            {
                res.IsSuccess= false;
            }
            return (res);
        }

        public async Task<ResponseDTO> GetCartItem(int id)
        {
            var d = await db.Carts.FirstOrDefaultAsync(x => x.Id == id);
            MyOrder m = new MyOrder();
            if (d != null)
            {
                var dd = await db.Items.FirstOrDefaultAsync(x => x.Id == d.ItemId);
                m.Id = d.Id;
                m.Qty = d.Qty;
                m.Price = d.Price;
                m.ImageUrl = dd.ImageUrl;
                m.ItemName = dd.ProdName;
                m.isdelivered = dd.Id;
                res.IsSuccess = true;
                res.Message = "Cart item found";
            }
            res.Result = m;
            return (res);
        }

        public async Task<ResponseDTO> ItemsInCart(int cid)
        {
            var d = await db.Carts.Where(x => x.UserId == cid).CountAsync();
            res.IsSuccess = true;
            res.Result = d;
            res.Message = Convert.ToString(d);
            return (res);
        }

        public async Task<ResponseDTO> ShowMyCart(int uid)
        {
            var d = await db.Carts.Where(x => x.UserId == uid).ToListAsync();
            List<MyOrder> list = new List<MyOrder>();
            foreach (var i in d)
            {
                var itemName = await db.Items.FindAsync(i.ItemId);
                var dto = new MyOrder()
                {
                    Id = i.Id,
                    Qty = i.Qty,
                    Price = i.Price,
                    ImageUrl = itemName.ImageUrl,
                    ItemName = itemName.ProdName,
                    uid=uid
                };
                list.Add(dto);
            }
            res.Result = list;
            res.IsSuccess=true;
            return (res);
        }
    }
}
