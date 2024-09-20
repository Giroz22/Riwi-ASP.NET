namespace RiwiStore.DTO
{
    public class UserResponse : UserDTO
    {
        public int Id { set; get; }
        public  IEnumerable<OrderToUserResponse>? Orders { set; get; }
    }
}