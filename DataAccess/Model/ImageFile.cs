using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class ImageFile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
        [NotMapped]
        public IFormFile? ImgFile { get; set; }

    }
}
