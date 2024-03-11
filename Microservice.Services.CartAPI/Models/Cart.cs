using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using Microservice.Services.AuthAPI.Model;
using Microservice.Servivices.CategoryAPI.Models;
namespace Microservice.Services.CartAPI.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }

        [Required]
        [ForeignKey("Items")]
        public int ItemId { get; set; }
        public Item? Items { get; set; }

        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public User? Users { get; set; }
    }
}
