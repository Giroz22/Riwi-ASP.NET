namespace RiwiStore.Model
{
    public class UserEntity
    {
        public int Id { set; get; }
        public string Names { set; get; } = "";
        public string? LastNames { set; get; }
        public string Email { set; get; } = "";
        public IEnumerable<PurchaseEntity> Purchases { set; get; } = new List<PurchaseEntity>();
    }    
}