
using DataAccess.Data;
using DataAccess.Model;
using Microservice.Services.CartAPI.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Services.CartAPI.Services
{
    public class ImageFileService : IImageFileService
    {
        private IWebHostEnvironment environment;
        private readonly ApplicationDbContext db;
        private readonly ResponseDTO res;
        public ImageFileService(IWebHostEnvironment environment,ApplicationDbContext db)
        {
            this.environment = environment;
            this.db = db;
            res = new ResponseDTO();
        }

        public async Task<bool> AddImage(ImageFile model)
        {
            byte[] imageData;
            using (var stream = new MemoryStream())
            {
                await model.ImgFile.CopyToAsync(stream);
                imageData = stream.ToArray();
            }
                ImageFile n = new ImageFile()
                {
                    ProductImage = model.ProductImage,
                    ProductName = model.ProductName,
                    ImgFile = model.ImgFile,
                    Imgbyte = imageData
                };
            await db.ImageFiles.AddAsync(n);   
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<ResponseDTO> GetImage()
        {
            var d = await db.ImageFiles.ToListAsync();
            res.Result = d;
            return (res);
        }

        public Tuple<int, string> SaveImage(IFormFile imgFile)
        {
            var contentPath=this.environment.ContentRootPath;
            var path = Path.Combine(contentPath, "Uploads");
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var ext = Path.GetExtension(imgFile.FileName);
            var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
            if(!allowedExtensions.Contains(ext))
            {
                string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
                return new Tuple<int, string>(0, msg);  
            }
            string uniqueString=Guid.NewGuid().ToString();
            var newFileName = uniqueString + ext;
            var fileWithpath=Path.Combine(path, newFileName);
            var stream = new FileStream(fileWithpath, FileMode.Create);
            imgFile.CopyTo(stream);
            stream.Close();
            return new Tuple<int, string>(1, newFileName);
        }
    }
}
