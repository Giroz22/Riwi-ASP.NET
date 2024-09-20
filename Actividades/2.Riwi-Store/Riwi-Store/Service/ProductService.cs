using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RiwiStore.Data;
using RiwiStore.DTO;
using RiwiStore.Model;

namespace RiwiStore.Services
{
    class ProductService : IProductService
    {
        private readonly BaseContext _context;

        private readonly IMapper _mapper;

        public ProductService(BaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductResponse>> GetAll()
        {
            var Products = await _context.Products.ToListAsync();

            return _mapper.Map<IEnumerable<ProductResponse>>(Products);
        }

        public async Task<ProductResponse> GetById(int id)
        {
            var order = await find(id);

            return _mapper.Map<ProductResponse>(order);
        }

        public async Task<ProductResponse> Create(ProductRequest requets)
        {
            ProductEntity order = _mapper.Map<ProductEntity>(requets);

            _context.Products.Add(order);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductResponse>(order);
        }    

        public async Task<ProductResponse> Update(int id, ProductRequest request)
        {
            var order = await find(id);

            _mapper.Map(request, order);

            _context.Products.Update(order);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductResponse>(order);
        }

        public async Task Delete(int id)
        {
            var order = await find(id);       
            _context.Products.Remove(order);
            await _context.SaveChangesAsync();                
        }

        private async Task<ProductEntity> find(int id)
        {
            var order = await _context.Products.FindAsync(id);

            if(order == null) throw new Exception("Product not found");

            return order;
        }
    }
}