
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.WebBlazor.DTO
{
    public class Item
    {
        
        public int Id { get; set; }
        public string ProdName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
       
        public int CategoryId { get; set; }
        
        public int IsActive { get; set; }
    }
}
