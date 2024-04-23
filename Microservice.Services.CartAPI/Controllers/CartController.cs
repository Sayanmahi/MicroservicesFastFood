using DataAccess.Model;
using Microservice.Services.CartAPI.Model.DTO;
using Microservice.Services.CartAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservice.Services.CartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartService db;
        private readonly IImageFileService imageFileService;
        public CartController(ICartService db,IImageFileService fs)
        {
            this.db = db;
            this.imageFileService = fs;
        }
        // GET: api/<CartController>
        [HttpGet("[action]")]
        public async Task<ResponseDTO> ShowMyCart(int uid)
        {
            var d= await db.ShowMyCart(uid);
            return (d);
        }

        // GET api/<CartController>/5
        [HttpGet("[action]")]
        public async Task<ResponseDTO> GetCartItem(int id)
        {
            var d= await db.GetCartItem(id);
            return (d);
        }

        // POST api/<CartController>
        [HttpPost("[action]")]
        public async Task<ResponseDTO> AddToCart(Cart cart)
        {
            var d = await db.AddToCart(cart);
            return (d);
        }

        // PUT api/<CartController>/5
        [HttpPut("[action]")]
        public async Task<ResponseDTO> EditItem(Cart cart)
        {
            var d= await db.EditItem(cart);
            return (d);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("[action]")]
        public async Task<ResponseDTO> DeleteItem(int id)
        {
            var d= await db.DeleteItem(id);
            return (d);
        }
        [HttpGet("[action]")]
        public async Task<ResponseDTO> ItemsInCart(int cid)
        {
            var d= await db.ItemsInCart(cid);
            return (d);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddImage([FromForm]ImageFile model)
        {
            
            if(model.ImgFile != null)
            {
                var fileResult=imageFileService.SaveImage(model.ImgFile);
                if(fileResult.Item1==1)
                {
                    model.ProductImage = fileResult.Item2;
                }

                //var res = await imageFileService.AddImage(model);
            }
            return Ok();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetImage()
        {
            //return Ok(await imageFileService.GetImage());
            return Ok(await imageFileService.GetImagesBytes());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetImageFromBytes()
        {
            return Ok(await imageFileService.GetImagesBytes());
        }
    }
}
