using Project.Database.Dtos.Common;

namespace Project.Database.Dtos.Response
{
    public class GetProductDetailsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StoreId { get; set; }
        public StoreDto Store { get; set; }
    }
}
