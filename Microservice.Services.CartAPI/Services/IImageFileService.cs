using DataAccess.Model;
using Microservice.Services.CartAPI.Model.DTO;

namespace Microservice.Services.CartAPI.Services
{
    public interface IImageFileService
    {
        public Tuple<int, string> SaveImage(IFormFile imgFile);
        public Task<bool> AddImage(ImageFile model);
        public Task<ResponseDTO> GetImage();
    }
}
