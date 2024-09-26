namespace RiwiStore.Model
{
    public class OrderEntity
    {
        public int Id { set; get; }
        public int numProducts { set; get; }
        public double subTotal { set; get; }

        //Product
        public int ProductId { set; get; }
        public required ProductEntity Product { set; get; }

        //Purchase
        public int PurchaseId { set;  get; }
        public required PurchaseEntity Purchase { set; get; } 
    }
}