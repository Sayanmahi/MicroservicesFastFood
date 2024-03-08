using System.ComponentModel.DataAnnotations;

namespace Microservice.Servivices.CategoryAPI.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
