﻿using Microservice.WebBlazor.DTO;

namespace Microservice.WebBlazor.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO?> SendAsync(RequestDTO requestDTO);
        Task<ResponseDTO?> SendLoginAsync(RequestDTO requestDTO);
        Task<ResponseDTO?> SendItemAsync(RequestDTO requestDTO);
        Task<ResponseDTO?> SendCartAsync(RequestDTO requestDTO);
        Task<ResponseDTO?> SendOrderAsync(RequestDTO requestDTO);

    }
}
