﻿using Microservices.Services.OrderAPI.DTO;

namespace Microservices.Services.OrderAPI.Services
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
