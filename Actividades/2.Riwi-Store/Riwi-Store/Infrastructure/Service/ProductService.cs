using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RiwiStore.API.DTOs;
using RiwiStore.Domain.Data;
using RiwiStore.Domain.Entities;


namespace RiwiStore.Infrastructure.Services
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
            var products = await _context.Products.Include(p=>p.Orders).ThenInclude(o=>o.Purchase).ThenInclude(pur=>pur.User).ToListAsync();

            return _mapper.Map<IEnumerable<ProductResponse>>(products);
        }

        public async Task<ProductResponse> GetById(int id)
        {
            var order = await Find(_context, id);

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
            var order = await Find(_context, id);

            _mapper.Map(request, order);

            _context.Products.Update(order);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductResponse>(order);
        }

        public async Task Delete(int id)
        {
            var order = await Find(_context, id);       
            _context.Products.Remove(order);
            await _context.SaveChangesAsync();                
        }

        public static async Task<ProductEntity> Find(BaseContext context, int id)
        {
            var product = await context.Products
                                        .Include(p => p.Orders)
                                        .ThenInclude(o=>o.Purchase)
                                        .ThenInclude(pur=>pur.User)
                                        .FirstOrDefaultAsync(p => p.Id == id);
                                        
            if(product == null) throw new Exception("Product not found");

            return product;
        }
    }
}