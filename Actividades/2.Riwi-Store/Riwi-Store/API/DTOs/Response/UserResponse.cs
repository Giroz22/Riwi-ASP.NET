namespace RiwiStore.DTO
{
    public class UserResponse : UserDTO
    {
        public  IEnumerable<OrderToUserResponse>? Orders { set; get; }
    }
}