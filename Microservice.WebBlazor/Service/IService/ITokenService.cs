namespace Microservice.WebBlazor.Service.IService
{
    public interface ITokenService
    {
        void SetUserToken(string token);
        void SetAdminToken(string token);
        string? GetUserToken();
        string? GetAdminToken();
        void ClearUserToken();
        void ClearAdminToken();

    }
}
