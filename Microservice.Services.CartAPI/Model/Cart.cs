using DataAccess.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Microservice.Services.CartAPI.Model
{
    public class Cart
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }

    }
}
