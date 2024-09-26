namespace RiwiStore.API.DTOs
{
    public class UserResponse : UserDTO
    {
        public  IEnumerable<PurchaseToUserReponse>? Purchases { set; get; }
    }
}