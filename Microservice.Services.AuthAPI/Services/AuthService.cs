using Microservice.Services.AuthAPI.Data;
using Microservice.Services.AuthAPI.Model;
using Microservice.Services.AuthAPI.Model.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Microservice.Services.AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext db;
        private readonly IConfiguration _config;
        private readonly ResponseDTO _res;
        public AuthService(AppDbContext db,IConfiguration _config)
        {
            this.db = db;
            this._config = _config;
            _res = new ResponseDTO();
        }
        public async Task<ResponseDTO> LoginAdmin(LoginDTO l)
        {
            var d= await db.users.FirstOrDefaultAsync(x=>x.Email==l.email && x.Password==l.password && x.userType.Equals("Admin"));
            if(d!=null)
            {
                var jwt=JwtGenerate(d.Email, "Admin", d.Id);
                _res.IsSuccess = true;
                _res.Result = jwt;
            }
            else
            {
                _res.IsSuccess = false;
            }
            return (_res);
        }

        public async Task<ResponseDTO> LoginUser(LoginDTO l)
        {
            var d = await db.users.FirstOrDefaultAsync(x => x.Email == l.email && x.Password == l.password && x.userType.Equals("User"));
            if (d != null)
            {
                var jwt = JwtGenerate(d.Email, "User", d.Id);
                _res.IsSuccess = true;
                _res.Result = jwt;
            }
            else
            {
                _res.IsSuccess = false;
            }
            return (_res);
        }

        public async Task<ResponseDTO> Register(UserDTO user)
        {
            User u = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                userType = "User"
            };
            await db.users.AddAsync(u);
            await db.SaveChangesAsync();
            _res.IsSuccess = true;
            return (_res);

        }
        private string JwtGenerate(string email, string role, int userid)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256); //security key is public key so hashing security key
            var claims = new[]//dismantling the payload datas
            {
                 new Claim("Email",email),
                 new Claim("UserId",userid.ToString()),
                 new Claim(ClaimTypes.Role,role)
                };
            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
