namespace Microservice.WebBlazor.Service.IService
{
    public interface ITokenService
    {
        void SetUserToken(string token,int uid);
        void SetAdminToken(string token);
        string? GetUserToken();
        int GetUserId();
        Task<string> GetAdminToken();
        void ClearUserToken();
        void ClearAdminToken();
        string GetUserType();

    }
}
