namespace RiwiStore.Domain.Entities
{
    public class ProductEntity
    {
        public int Id { set; get; }
        public string Name { set; get; } = "";
        public string? Description { set; get; }
        public double Price { set; get; } = 0;
        public IEnumerable<OrderEntity> Orders { set; get; } = new List<OrderEntity>();
    }
}