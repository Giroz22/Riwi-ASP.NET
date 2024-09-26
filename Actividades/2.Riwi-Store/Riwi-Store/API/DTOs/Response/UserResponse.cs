namespace RiwiStore.DTO
{
    public class UserResponse : UserDTO
    {
        public  IEnumerable<PurchaseToUserReponse>? Purchases { set; get; }
    }
}