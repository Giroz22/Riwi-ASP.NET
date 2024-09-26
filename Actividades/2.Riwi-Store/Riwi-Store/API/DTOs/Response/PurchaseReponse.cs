namespace RiwiStore.API.DTOs
{
    public class PurchaseResponse
    {
        public int Id { get; set;}
        public double TotalAmount { get; set;}
        public DateTime PurchaseDate { get; set;}
        public required UserDTO User { get; set;}
        public List<OrderResponse> Orders { get; set;} = new List<OrderResponse>();
    }

}
