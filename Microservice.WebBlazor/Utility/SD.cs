namespace Microservice.WebBlazor.Utility
{
    public class SD
    {
        public static string CategoryAPIBase {  get; set; } 
        public static string LoginAPIBase { get; set; }
        public static string ItemAPIBase { get; set; }
        public static string CartAPI { get; set; }
        public const string UserToken = "UserToken";
        public const string AdminToken = "AdminToken";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
