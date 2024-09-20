namespace RiwiStore.Model
{
    public class ProductEntity
    {
        public int Id { set; get; }
        public string? Name { set; get; }
        public string? Description { set; get; }
        public decimal Price { set; get; }
        public ICollection<OrderEntity>? Orders { set; get; }
    }
}