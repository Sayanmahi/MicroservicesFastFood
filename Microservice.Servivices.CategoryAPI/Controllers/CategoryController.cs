using Microservice.Services.CategoryAPI.Models.DTO;
using Microservice.Services.CategoryAPI.Services;
using Microservice.Servivices.CategoryAPI.Models;
using Microservice.Servivices.CategoryAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservice.Services.CategoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private ICategoryService db;
        public CategoryController(ICategoryService db)
        {
            this.db = db;
        }
        // GET: api/<CategoryController>
        [HttpGet("[action]")]
        public async Task<ResponseDTO> GetAllCategories()
        {
            var d= await db.GetAllCategories();
            return(d);
        }

        // GET api/<CategoryController>/5
        [HttpPut("[action]")]
        public async Task<ResponseDTO> EditCategory(CategoryDTO cat)
        {
            var d = await db.EditCategory(cat);
            return (d);
        }

        // POST api/<CategoryController>
        [HttpPost("[action]")]
        public async Task<ResponseDTO> AddCategory([FromBody] CategoryDTO cat)
        {
            var d= await db.AddCategory(cat);
            return (d);
        }

        // PUT api/<CategoryController>/5
        [HttpGet("[action]")]
        public async Task<ResponseDTO> GetCategoryById(int id)
        {
            var d= await db.GetCategoryById(id);
            return (d);
        }
    }
}
