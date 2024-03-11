using Microservice.WebBlazor.Utility;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Microservice.WebBlazor.Service.IService
{
    public class TokenService : ITokenService
    {
        public static string Usertoken="";
        public static string Admintoken = "";

        public IHttpContextAccessor db;
        public TokenService(IHttpContextAccessor db)
        {
            this.db = db;
        }
        public void ClearUserToken()
        {
            Usertoken = "";
        }

        public string? GetUserToken()
        {
            return Usertoken;
            //string? token = null;
            //bool? hasToken= db.HttpContext?.Request.Cookies.TryGetValue(SD.UserToken, out token);
            //return hasToken is true ? token : null;
        }

        public void SetUserToken(string token)
        {
            Usertoken = token;
            //try
            //{
               // db.HttpContext.Response.Cookies.Append(SD.UserToken, token);
            //}
            //catch(Exception ex)
            //{

            //}
        }
        public void SetAdminToken(string token)
        {
            Admintoken=token;
            //db.HttpContext?.Response.Cookies.Append(SD.UserToken, token);
        }

        public string? GetAdminToken()
        {
            return Admintoken;
            //string? token = null;
            //bool? hasToken = db.HttpContext?.Request.Cookies.TryGetValue(SD.AdminToken, out token);
            //return hasToken is true ? token : null;
        }

        public void ClearAdminToken()
        {
            Admintoken = "";
            //db.HttpContext?.Response.Cookies.Delete(SD.AdminToken);
        }
    }
}
