using Microsoft.AspNetCore.Mvc;
using Microservices.Services.OrderAPI.DTO;
using Microservices.Services.OrderAPI.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservices.Services.OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService db;
        public OrderController(IOrderService db)
        {
            this.db = db;
        }
        // GET: api/<OrderController>
        [HttpGet("[action]")]
        public async Task<ResponseDTO> GetAllOrders()
        {
            var d = await db.GetAllOrders();
            return (d);
        }

        // GET api/<OrderController>/5
        [HttpGet("[action]")]
        public async Task<ResponseDTO> GetOrdersNotDelivered()
        {
            var d= await db.GetOrdersNotDelivered();
            return (d);
        }

        // POST api/<OrderController>
        [HttpGet("[action]")]
        public async Task<ResponseDTO> MyOrders(int id)
        {
            var d= await db.MyOrders(id);
            return (d);
        }

        // PUT api/<OrderController>/5
        [HttpPut("[action]")]
        public async Task<ResponseDTO> OrderIsPreparing(int id)
        {
            var d = await db.OrderIsPreparing(id);
            return (d);
        }

        // DELETE api/<OrderController>/5
        [HttpPost("[action]")]
        public async Task<ResponseDTO> PlaceOrder(MyOrder orders)
        {
            var d= await db.PlaceOrder(orders);
            return (d);
        }
        [HttpGet("[action]")]
        public async Task<ResponseDTO> ShowMyUndeliveredOrders(int id)
        {
            var d= await db.ShowMyUndeliveredOrders(id);
            return (d);
        }
        [HttpPut("[action]")]
        public async Task<ResponseDTO> VlidateisDeliveredOrder(int id)
        {
            var d = await db.ValidateisDelieredOrder(id);
            return (d);
        }
    }
}
