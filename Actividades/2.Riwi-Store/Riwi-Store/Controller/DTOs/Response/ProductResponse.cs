namespace RiwiStore.DTO
{
    public class ProductResponse : ProductDTO
    {
        public int Id { set; get; }
        public IEnumerable<OrderToProductResponse>? Orders { set; get; }
    }
}