using Blazored.LocalStorage;
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
        public static string UserType = "";
        public static string AdminType = "";

        public IHttpContextAccessor db;
        public ILocalStorageService local;
        public TokenService(IHttpContextAccessor db,ILocalStorageService local)
        {
            this.db = db;
            this.local = local;

        }

        public void ClearAdminToken()
        {
            Admintoken = "";
            AdminType = "";
            local.RemoveItemAsync("AdminToken");
        }

        public void ClearUserToken()
        {
            Usertoken = "";
            userid = -999;
            UserType = "";
            local.RemoveItemAsync("UserToken");
        }

        public async Task<string> GetAdminToken()
        {
            var p = Convert.ToString(await local.GetItemAsStringAsync("AdminToken"));
            return (p);
        }

        public int GetUserId()
        {
            return(userid);
        }

        public string? GetUserToken()
        {
            var p = Convert.ToString(local.GetItemAsStringAsync("UserToken"));
            return (Usertoken);
        }

        public string GetUserType()
        {
            if(Admintoken.Equals(""))
            {
                return (UserType);
            }
            else
            {
                return (AdminType);
            }
        }

        public void SetAdminToken(string token)
        {
            Admintoken = token;
            AdminType = "Admin";
            ClearUserToken();
        }

        public void SetUserToken(string token, int uid)
        {
            Usertoken=token;
            userid = uid;
            UserType = "User";
            ClearAdminToken();
        }
    }
}
