using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RiwiStore.Data;
using RiwiStore.DTO;
using RiwiStore.Model;

namespace RiwiStore.Services
{
    class OrderService : IOrderService
    {
        private readonly BaseContext _context;

        private readonly IMapper _mapper;

        public OrderService(BaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderResponse>> GetAll()
        {
            var Orders = await _context.Orders
                               .Include(o => o.Product) 
                               .Include(o => o.User)    
                               .ToListAsync();

            return _mapper.Map<IEnumerable<OrderResponse>>(Orders);
        }

        public async Task<OrderResponse> GetById(int id)
        {
            var order = await find(id);

            return _mapper.Map<OrderResponse>(order);
        }

        public async Task<OrderResponse> Create(OrderRequest requets)
        {
            OrderEntity order = _mapper.Map<OrderEntity>(requets);
            order.Product = await findProduct(requets.ProductId); 
            order.User = await findUser(requets.UserId); 

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return _mapper.Map<OrderResponse>(order);
        }    

        public async Task<OrderResponse> Update(int id, OrderRequest request)
        {
            var order = await find(id);

            _mapper.Map(request, order);

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderResponse>(order);
        }

        public async Task Delete(int id)
        {
            var order = await find(id);       
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();                
        }

        private async Task<OrderEntity> find(int id)
        {
            var order = await _context.Orders
                              .Include(o => o.Product) 
                              .Include(o => o.User)    
                              .FirstOrDefaultAsync(o => o.Id == id);

            if(order == null) throw new Exception("Order not found");

            return order;
        }

        private async Task<ProductEntity> findProduct(int id)
        {
            var order = await _context.Products.FindAsync(id);

            if(order == null) throw new Exception("Product not found");

            return order;
        }

        private async Task<UserEntity> findUser(int id)
        {
            var order = await _context.Users.FindAsync(id);

            if(order == null) throw new Exception("User not found");

            return order;
        }
    }
}