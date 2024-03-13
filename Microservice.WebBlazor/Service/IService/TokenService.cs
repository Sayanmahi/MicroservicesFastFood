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
        public static int userid = -999;

        public IHttpContextAccessor db;
        public TokenService(IHttpContextAccessor db)
        {
            this.db = db;
        }

        public void ClearAdminToken()
        {
            Admintoken = "";
        }

        public void ClearUserToken()
        {
            Usertoken = "";
            userid = -999;
        }

        public string? GetAdminToken()
        {
            return (Admintoken);
        }

        public int GetUserId()
        {
            return(userid);
        }

        public string? GetUserToken()
        {
            return (Usertoken);
        }

        public void SetAdminToken(string token)
        {
            Admintoken = token;
        }

        public void SetUserToken(string token, int uid)
        {
            Usertoken=token;
            userid = uid;
        }
    }
}
