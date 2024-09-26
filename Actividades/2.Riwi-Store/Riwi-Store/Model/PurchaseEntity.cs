using RiwiStore.DTO;

namespace RiwiStore.Model
{
    public class PurchaseEntity
    {
        public int Id { get; set;}
        public double TotalAmount { get; set;} = 0;
        public DateTime PurchaseDate { get; set;}
        
        //User relation
        public int UserId;
        public required UserEntity User { get; set;}
        
        //Order relation
        public IEnumerable<OrderEntity> Orders { get; set;} = new List<OrderEntity>();
    }

}
