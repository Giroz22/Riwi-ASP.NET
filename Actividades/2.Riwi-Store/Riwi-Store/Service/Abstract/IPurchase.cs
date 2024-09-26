
using RiwiStore.DTO;

public interface IPurchaseService :
    IGetAll<PurchaseResponse>,
    IGetById<int, PurchaseResponse>,
    ICreate<PurchaseRequest, PurchaseResponse>,
    IUpdate<int, PurchaseRequest,PurchaseResponse>,
    IDelete<int>
{
    
}