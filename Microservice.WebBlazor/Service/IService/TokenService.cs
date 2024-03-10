using Microservice.WebBlazor.Utility;
using Newtonsoft.Json.Linq;

namespace Microservice.WebBlazor.Service.IService
{
    public class TokenService : ITokenService
    {
        private readonly IHttpContextAccessor db;
        public TokenService(IHttpContextAccessor db)
        {
            this.db = db;
        }
        public void ClearUserToken()
        {
            db.HttpContext?.Response.Cookies.Delete(SD.UserToken);
        }

        public string? GetUserToken()
        {
            string? token = null;
            bool? hasToken= db.HttpContext?.Request.Cookies.TryGetValue(SD.UserToken, out token);
            return hasToken is true ? token : null;
        }

        public void SetUserToken(string token)
        {
            db.HttpContext?.Response.Cookies.Append(SD.UserToken, token);
        }
        public void SetAdminToken(string token)
        {
            db.HttpContext?.Response.Cookies.Append(SD.UserToken, token);
        }

        public string? GetAdminToken()
        {
            string? token = null;
            bool? hasToken = db.HttpContext?.Request.Cookies.TryGetValue(SD.AdminToken, out token);
            return hasToken is true ? token : null;
        }

        public void ClearAdminToken()
        {
            db.HttpContext?.Response.Cookies.Delete(SD.AdminToken);
        }
    }
}
