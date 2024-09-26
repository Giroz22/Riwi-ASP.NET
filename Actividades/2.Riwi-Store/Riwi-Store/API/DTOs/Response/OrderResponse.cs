namespace RiwiStore.DTO
{
    public class OrderResponse
    {
        public int Id { set; get; }

        public int numProducts { set; get; }
        public double subTotal { set; get; }

        //Product
        public ProductDTO? Product {set; get;}
    }
}