namespace RiwiStore.Model
{
    public class OrderEntity
    {
        public int Id { set; get; }

        //Product
        public int ProductId {set; get;}
        public ProductEntity? Product { set; get; }

        //User
        public int UserId { set;  get; }
        public UserEntity? User { set; get; } 
    }
}