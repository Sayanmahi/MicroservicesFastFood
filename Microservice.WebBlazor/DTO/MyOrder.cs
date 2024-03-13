namespace Microservice.WebBlazor.DTO
{
    public class MyOrder
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int uid { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public string ItemName { get; set; }
        public DateTime date { get; set; }
        public int isdelivered { get; set; }
    }
}
