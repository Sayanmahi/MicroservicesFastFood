using Microservice.WebBlazor.DTO;

namespace Microservice.WebBlazor.Service.IService
{
    public interface IOrderService
    {
        Task<ResponseDTO> GetAllOrders();
        Task<ResponseDTO> GetOrdersNotDelivered();
        Task<ResponseDTO> ValidateisDelieredOrder(int id);
        Task<ResponseDTO> PlaceOrder(MyOrder orders);
        Task<ResponseDTO> MyOrders(int id);
        Task<ResponseDTO> ShowMyUndeliveredOrders(int id);
        Task<ResponseDTO> OrderIsPreparing(int id);
    }
}
