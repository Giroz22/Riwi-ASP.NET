using RiwiStore.DTO;
using RiwiStore.Model;

public interface IOrderService
{
    Task<OrderEntity> CalculateSubTotal(OrderEntity order);
}