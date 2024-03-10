using Microservice.Services.AuthAPI.Model.DTO;
using Microservice.Services.AuthAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservice.Services.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService db;
        public AuthController(IAuthService db)
        {
            this.db = db;
        }
        // GET: api/<AuthController>
        [HttpPost("[action]")]
        public async Task<ResponseDTO> LoginAdmin(LoginDTO l)
        {
            var d = await db.LoginAdmin(l);
            return (d);
        }

        // GET api/<AuthController>/5
        [HttpPost("[action]")]
        public async Task<ResponseDTO> LoginUser(LoginDTO l)
        {
            var d = await db.LoginUser(l);
            return (d);
        }

        // POST api/<AuthController>
        [HttpPost("[action]")]
        public async Task<ResponseDTO> Register(UserDTO u)
        {
            var d= await db.Register(u);
            return (d);
        }
        [HttpPost("[action]")]
        public async Task<ResponseDTO> RegisterUser(UserDTO user)
        {
            var d = await db.Register(user);
            return (d);
        }
        
    }
}
