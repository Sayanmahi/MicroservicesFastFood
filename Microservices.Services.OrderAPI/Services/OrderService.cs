using DataAccess.Data;
using DataAccess.Model;
using Microservices.Services.OrderAPI.DTO;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Microservices.Services.OrderAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _foodDbContext;
        private readonly ResponseDTO res;
        public OrderService(ApplicationDbContext _foodDbContext)
        {
            this._foodDbContext = _foodDbContext;
            res= new ResponseDTO();
        }
        public async Task<ResponseDTO> GetAllOrders()
        {
            var data = await _foodDbContext.Orders.ToListAsync();
            List<GetAllOrderDTO> d = new List<GetAllOrderDTO>();
            if (data != null)
            {
                foreach (var i in data)
                {
                    var da = await _foodDbContext.users.FindAsync(i.UserId);
                    var itemname = await _foodDbContext.Items.FindAsync(i.ItemId);
                    var dto = new GetAllOrderDTO()
                    {
                        Id = i.Id,
                        Qty = i.Qty,
                        Price = i.Price,
                        ItemName = itemname.ProdName,
                        date = i.date,
                        isdelivered = i.isdelivered,
                        UserName = da.Name,
                        PhoneNo = da.PhoneNumber,
                        ImageUrl = itemname.ImageUrl
                    };
                    d.Add(dto);
                }
            }
            res.Result = d;
            res.IsSuccess = true;
            res.Message = "All Orders";
            return (res);
            
        }

        public async Task<ResponseDTO> GetOrdersNotDelivered()
        {
            var data = await _foodDbContext.Orders.Where(x => x.isdelivered == 1 || x.isdelivered == 2).ToListAsync();
            List<GetAllOrderDTO> d = new List<GetAllOrderDTO>();
            if (data != null)
            {
                foreach (var i in data)
                {
                    var da = await _foodDbContext.users.FindAsync(i.UserId);
                    var itemname = await _foodDbContext.Items.FindAsync(i.ItemId);
                    var dto = new GetAllOrderDTO()
                    {
                        Id = i.Id,
                        Qty = i.Qty,
                        ImageUrl = itemname.ImageUrl,
                        Price = i.Price,
                        ItemName = itemname.ProdName,
                        date = i.date,
                        isdelivered = i.isdelivered,
                        UserName = da.Name,
                        PhoneNo = da.PhoneNumber
                    };
                    d.Add(dto);
                }
            }
            res.Result = d;
            res.IsSuccess = true;
            res.Message = "Orders not delivered";
            return (res);
        }

        public async Task<ResponseDTO> MyOrders(int id)
        {
            var d = await _foodDbContext.Orders.Where(x => x.UserId == id && x.isdelivered == 1).OrderByDescending(x => x.date).ToListAsync();
            List<MyOrder> l = new List<MyOrder>();
            if (d != null)
            {
                foreach (var i in d)
                {
                    var dd = await _foodDbContext.Items.FirstOrDefaultAsync(x => x.Id == i.ItemId);
                    MyOrder n = new MyOrder()
                    {
                        Id = i.Id,
                        Qty = i.Qty,
                        Price = i.Price,
                        ItemName = dd.ProdName,
                        date = i.date,
                        isdelivered = i.isdelivered,
                        ImageUrl = dd.ImageUrl
                    };
                    l.Add(n);
                }
                

            }
            var d1 = await _foodDbContext.Orders.Where(x => x.UserId == id && (x.isdelivered == 2 || x.isdelivered == 0)).ToListAsync();
            if (d1 != null)
            {
                foreach (var i in d1)
                {
                    var dd = await _foodDbContext.Items.FirstOrDefaultAsync(x => x.Id == i.ItemId);
                    MyOrder n = new MyOrder()
                    {
                        Id = i.Id,
                        Qty = i.Qty,
                        Price = i.Price,
                        ItemName = dd.ProdName,
                        date = i.date,
                        isdelivered = i.isdelivered,
                        ImageUrl = dd.ImageUrl
                    };
                    l.Add(n);
                }
            }
            res.Result = l;
            res.IsSuccess = true;
            res.Message = "My orders";
            return (res);
        }

        public async Task<ResponseDTO> OrderIsPreparing(int id)
        {
            var d = await _foodDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
            d.isdelivered = 2;
            await _foodDbContext.SaveChangesAsync();
            res.IsSuccess = true;
            res.Message = "Order state changed";
            return (res);
        }

        public async Task<ResponseDTO> PlaceOrder(MyOrder orders)
        {
            try
            {
                Order o = new Order();
                o.isdelivered = 1;
                o.date = DateTime.Now;
                o.Qty = orders.Qty;
                o.Price = orders.Price;
                o.UserId = orders.uid;
                var d = await _foodDbContext.Items.FirstOrDefaultAsync(x => x.ProdName.Equals(orders.ItemName));
                o.ItemId = d.Id;
                await _foodDbContext.AddAsync(o);
                await _foodDbContext.SaveChangesAsync();
                var data = await _foodDbContext.Carts.FirstOrDefaultAsync(x => x.Id == orders.Id);
                _foodDbContext.Carts.Remove(data);
                await _foodDbContext.SaveChangesAsync();
                res.IsSuccess= true;
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
            }
            return (res);
        }

        public async Task<ResponseDTO> ShowMyUndeliveredOrders(int id)
        {
            var d = await _foodDbContext.Orders.Where(x => x.UserId == id && x.isdelivered == 1).ToListAsync();
            List<MyOrder> orders = new List<MyOrder>();
            if (d != null)
            {
                foreach (var i in d)
                {
                    var c = await _foodDbContext.Items.FindAsync(i.ItemId);
                    var f = new MyOrder()
                    {
                        Id = i.Id,
                        Qty = i.Qty,
                        Price = i.Price,
                        ItemName = c.ProdName,
                        date = i.date,
                        isdelivered = i.isdelivered,
                        ImageUrl = c.ImageUrl
                    };
                    orders.Add(f);
                }
            }
            res.Result= orders;
            res.IsSuccess = true;
            res.Message = "List of undelivered Items";
            return (res);
        }

        public async Task<ResponseDTO> ValidateisDelieredOrder(int id)
        {
            var d = await _foodDbContext.Orders.FindAsync(id);
            if (d != null)
            {
                d.isdelivered = 0;
                await _foodDbContext.SaveChangesAsync();
                res.IsSuccess= true;
                res.Message = "Order is validated";
            }
            else
            {
                res.IsSuccess = false;
                res.Message = "Order cannot be validated";
            }
            return (res);
        }
    }
}
