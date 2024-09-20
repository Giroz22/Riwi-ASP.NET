using RiwiStore.DTO;

public interface IOrderService : 
    IGetAll<OrderResponse>,
    IGetById<int, OrderResponse>,
    ICreate<OrderRequest, OrderResponse>,
    IUpdate<int, OrderRequest,OrderResponse>,
    IDelete<int>
{
    
}