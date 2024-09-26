using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RiwiStore.Data;
using RiwiStore.DTO;
using RiwiStore.Model;

namespace RiwiStore.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly BaseContext _context;

        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public PurchaseService(BaseContext context, IMapper mapper, IOrderService orderService)
        {
            _context = context;
            _mapper = mapper;
            _orderService = orderService;
        }

        public async Task<IEnumerable<PurchaseResponse>> GetAll()
        {
            var Purchases = await _context.Purchases.Include(pur=>pur.User).Include(pur=>pur.Orders).ThenInclude(o=>o.Product).ToListAsync();

            return _mapper.Map<IEnumerable<PurchaseResponse>>(Purchases);
        }

        public async Task<PurchaseResponse> GetById(int id)
        {
            var purchase = await Find(_context, id);

            return _mapper.Map<PurchaseResponse>(purchase);
        }

        public async Task<PurchaseResponse> Create(PurchaseRequest request)
        {
            PurchaseEntity purchase = _mapper.Map<PurchaseEntity>(request);

            //Business logic
            //Find User
            purchase.User = await UserService.Find(_context, purchase.UserId); 
            purchase.PurchaseDate = DateTime.Now;   

            //Calculate
            foreach (var ord in purchase.Orders)
            {
                OrderEntity order = await _orderService.CalculateSubTotal(ord);
                purchase.TotalAmount += order.subTotal;  
            }                               

            //Add Purchase
            await _context.Purchases.AddAsync(purchase);
            await _context.SaveChangesAsync();        

            return _mapper.Map<PurchaseResponse>(purchase);
        }    

        public async Task<PurchaseResponse> Update(int id, PurchaseRequest request)
        {
            var purchase = await Find(_context, id);

            _mapper.Map(request, purchase);

            foreach (var ord in purchase.Orders)
            {
                OrderEntity order = await _orderService.CalculateSubTotal(ord);
                purchase.TotalAmount += order.subTotal;  
            }  

            _context.Purchases.Update(purchase);
            await _context.SaveChangesAsync();

            return _mapper.Map<PurchaseResponse>(purchase);
        }

        public async Task Delete(int id)
        {
            var purchase = await Find(_context, id);       
            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();                
        }

        public static async Task<PurchaseEntity> Find(BaseContext context,int id)
        {
            var purchase = await context.Purchases
                                        .Include(pur => pur.User)
                                        .Include(pur=>pur.Orders)
                                        .ThenInclude(o=>o.Product)                                           
                                        .FirstOrDefaultAsync(u => u.Id == id);

            if(purchase == null) throw new Exception("Purchase not found");

            return purchase;
        }
    }
}