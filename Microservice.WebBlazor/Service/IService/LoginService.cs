using Microservice.WebBlazor.DTO;
using Microservice.WebBlazor.Utility;

namespace Microservice.WebBlazor.Service.IService
{
    public class LoginService : ILoginService
    {
        private readonly IBaseService db;
        public LoginService(IBaseService db)
        {
            this.db = db;
        }
        public Task<ResponseDTO?> LoginAdmin(LoginDTO l)
        {
            return db.SendLoginAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = l,
                Url = SD.LoginAPIBase + "/api/Auth/LoginAdmin"


            });
        }

        public Task<ResponseDTO?> LoginUser(LoginDTO l)
        {
            return db.SendLoginAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = l,
                Url = SD.LoginAPIBase + "/api/Auth/LoginUser"


            });
        }

        public Task<ResponseDTO?> Register(UserDTO user)
        {
            return db.SendLoginAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = user,
                Url = SD.LoginAPIBase+"/api/Auth/RegisterUser"


            });
        }
    }
}
