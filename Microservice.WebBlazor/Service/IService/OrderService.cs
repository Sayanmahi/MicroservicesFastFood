using Microservice.WebBlazor.DTO;
using Microservice.WebBlazor.Utility;

namespace Microservice.WebBlazor.Service.IService
{
    public class OrderService : IOrderService
    {
        private readonly IBaseService _baseService;
        public OrderService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDTO> GetAllOrders(string token)
        {
            return await _baseService.SendOrderAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                AccessToken=token,
                Url = "https://localhost:7030/api/Order/GetAllOrders"
            });
        }

        public async Task<ResponseDTO> GetOrdersNotDelivered(string token)
        {
            return await _baseService.SendOrderAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                AccessToken=token,
                Url = "https://localhost:7030/api/Order/GetOrdersNotDelivered"
            });
        }

        public async Task<ResponseDTO> MyOrders(int id,string token)
        {
            return await _baseService.SendOrderAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                AccessToken=token,  
                Url = "https://localhost:7030/api/Order/MyOrders?id="+id
            });
        }

        public async Task<ResponseDTO> OrderIsPreparing(int id, string token)
        {
            return await _baseService.SendOrderAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
                AccessToken=token,
                Url = "https://localhost:7030/api/Order/OrderIsPreparing?id=" + id
            });
        }

        public async Task<ResponseDTO> PlaceOrder(MyOrder orders, string token)
        {
            return await _baseService.SendOrderAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = orders,
                AccessToken=token,
                Url = "https://localhost:7030/api/Order/PlaceOrder"


            });
        }

        public async Task<ResponseDTO> ShowMyUndeliveredOrders(int id,string token)
        {
            return await _baseService.SendOrderAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                AccessToken=token,
                Url = "https://localhost:7030/api/Order/ShowMyUndeliveredOrders?id="+id
            });
        }

        public async Task<ResponseDTO> ValidateisDelieredOrder(int id, string token)
        {
            return await _baseService.SendOrderAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
                AccessToken=token,
                Url = "https://localhost:7030/api/Order/VlidateisDeliveredOrder?id=" + id
            });
        }
    }
}
