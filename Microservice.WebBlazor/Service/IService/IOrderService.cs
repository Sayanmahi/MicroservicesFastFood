using Microservice.WebBlazor.DTO;

namespace Microservice.WebBlazor.Service.IService
{
    public interface IOrderService
    {
        Task<ResponseDTO> GetAllOrders(string token);
        Task<ResponseDTO> GetOrdersNotDelivered(string token);
        Task<ResponseDTO> ValidateisDelieredOrder(int id,string token);
        Task<ResponseDTO> PlaceOrder(MyOrder orders,string token);
        Task<ResponseDTO> MyOrders(int id, string token);
        Task<ResponseDTO> ShowMyUndeliveredOrders(int id,string token);
        Task<ResponseDTO> OrderIsPreparing(int id,string token);
    }
}
