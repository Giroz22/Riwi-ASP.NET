namespace RiwiStore.DTO
{
    public class OrderResponse
    {
        public int Id { set; get; }

        //Product
        public ProductDTO? Product {set; get;}

        //User
        public UserDTO? User { set;  get; }
    }
}