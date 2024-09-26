using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RiwiStore.Domain.Data;
using RiwiStore.Domain.Entities;

namespace RiwiStore.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly BaseContext _context;

        private readonly IMapper _mapper;

        public OrderService(BaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderEntity> CalculateSubTotal(OrderEntity order)
        {
            order.Product = await ProductService.Find(_context, order.ProductId);            
            order.subTotal = Math.Round(order.numProducts * order.Product.Price, 2);

            return order;
        }    

        public static async Task<OrderEntity> Find(BaseContext context, int id)
        {
            var order = await context.Orders
                              .Include(o => o.Product) 
                              .FirstOrDefaultAsync(o => o.Id == id);

            if(order == null) throw new Exception("Order not found");

            return order;
        }
    }
}