namespace RiwiStore.API.DTOs
{
    public class ProductRequest
    {
        public string? Name { set; get; }
        public string? Description { set; get; }
        public decimal Price { set; get; }
    }
}