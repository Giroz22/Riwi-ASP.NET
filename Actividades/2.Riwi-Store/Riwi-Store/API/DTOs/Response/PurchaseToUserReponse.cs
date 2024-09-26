namespace RiwiStore.DTO
{
    public class PurchaseToUserReponse
    {
        public int Id { get; set;}
        public double TotalAmount { get; set;}
        public DateTime PurchaseDate { get; set;}
        public List<OrderResponse> Orders { get; set;} = new List<OrderResponse>();
    }

}
