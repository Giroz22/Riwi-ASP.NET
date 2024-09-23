namespace RiwiStore.DTO
{
    public class ProductResponse : ProductDTO
    {        
        public IEnumerable<OrderToProductResponse>? Orders { set; get; }
    }
}