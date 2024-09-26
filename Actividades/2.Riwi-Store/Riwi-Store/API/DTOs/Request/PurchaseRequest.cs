namespace RiwiStore.API.DTOs
{
    public class PurchaseRequest
    {    
        public int UserId { get; set;}
        public List<OrderRequest> Orders { get; set;} = new List<OrderRequest>();
    }

}
