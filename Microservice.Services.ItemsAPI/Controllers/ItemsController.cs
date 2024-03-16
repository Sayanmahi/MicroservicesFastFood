using DataAccess.Model;
using Microservice.Services.ItemsAPI.Models.DTO;
using Microservice.Services.ItemsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservice.Services.ItemsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService db;

        public ItemsController(IItemService db)
        {
            this.db = db;
        }
        // GET: api/<ItemsController>
        [HttpGet("[action]")]
        public async Task<ResponseDTO> GetItemsBasedOnCategory(int catid)
        {
            var d = await db.GetItemsBasedOnCategory(catid);
            return (d);
        }

        // GET api/<ItemsController>/5
        [HttpGet("[action]")]
        public async Task<ResponseDTO> GetItemById(int id)
        {
            var d= await db.GetItemById(id);
            return (d);
        }

        // POST api/<ItemsController>
        [HttpGet("[action]")]
        public async Task<ResponseDTO> GetAllItems()
        {
            var d= await db.GetAllItems();
            return (d);
        }

        // PUT api/<ItemsController>/5
        [HttpPut("[action]")]
        public async Task<ResponseDTO> EditItem(Item i)
        {
            var d = await db.EditItem(i);
            return (d);

        }

        // DELETE api/<ItemsController>/5
        [HttpPut("[action]")]
        public async Task<ResponseDTO> ChangeCategory(int itemid,int catid)
        {
            var d= await db.ChangeCategory(itemid,catid);
            return (d);
        }
        [HttpGet("[action]")]
        public async Task<ResponseDTO> AdminGetItemsBasedOnCategory(int CategoryId)
        {
            var d= await db.AdminGetItemsBasedOnCategory(CategoryId);
            return (d);
        }
        [HttpPost("[action]")]
        public async Task<ResponseDTO> AddItem(Item item)
        {
            var d = await db.AddItem(item);
            return (d);
        }
        [HttpPut("[action]")]
        public async Task<ResponseDTO> ActivateItem(int itemid)
        {
            var d= await db.ActivateItem(itemid);
            return (d);
        }
        [HttpPut("[action]")]
        public async Task<ResponseDTO> InActiveItem(int id)
        {
            var d= await db.InActiveItem(id);
            return (d);
        }

    }
}
