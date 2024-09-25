namespace RiwiStore.Model
{
    public class OrderEntity
    {
        public int Id { set; get; }

        //Product
        public int ProductId { set; get; }
        public required ProductEntity Product { set; get; }

        //User
        public int UserId { set;  get; }
        public required UserEntity User { set; get; } 
    }
}