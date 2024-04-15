using DataAccess.Model;

namespace Microservice.Services.CartAPI.Services
{
    public interface IImageFileService
    {
        public Tuple<int, string> SaveImage(IFormFile imgFile);
        public bool AddImage(ImageFile model);
        public IFormFile GetImage(string imgaFileName);
    }
}
