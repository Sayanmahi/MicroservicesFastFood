using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Microservice.WebBlazor.DTO
{
    public class ImageFile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
        public byte[] Imgbyte { get; set; }
        [NotMapped]
        public IFormFile? ImgFile { get; set; }
        public string? BToImg { get; set; }
    }
}
