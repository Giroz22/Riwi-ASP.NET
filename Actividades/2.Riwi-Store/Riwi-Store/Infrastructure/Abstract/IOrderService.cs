using RiwiStore.Domain.Entities;

public interface IOrderService
{
    Task<OrderEntity> CalculateSubTotal(OrderEntity order);
}