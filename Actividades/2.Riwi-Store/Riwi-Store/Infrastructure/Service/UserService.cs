using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RiwiStore.API.DTOs;
using RiwiStore.Domain.Data;
using RiwiStore.Domain.Entities;

namespace RiwiStore.Infrastructure.Services
{
    class UserService : IUserService
    {
        private readonly BaseContext _context;

        private readonly IMapper _mapper;

        public UserService(BaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResponse>> GetAll()
        {
            var Users = await _context.Users.Include(u=>u.Purchases).ThenInclude(pur=>pur.Orders).ThenInclude(o=>o.Product).ToListAsync();

            return _mapper.Map<IEnumerable<UserResponse>>(Users);
        }

        public async Task<UserResponse> GetById(int id)
        {
            var order = await Find(_context, id);

            return _mapper.Map<UserResponse>(order);
        }

        public async Task<UserResponse> Create(UserRequest requets)
        {
            UserEntity order = _mapper.Map<UserEntity>(requets);

            _context.Users.Add(order);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserResponse>(order);
        }    

        public async Task<UserResponse> Update(int id, UserRequest request)
        {
            var order = await Find(_context, id);

            _mapper.Map(request, order);

            _context.Users.Update(order);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserResponse>(order);
        }

        public async Task Delete(int id)
        {
            var order = await Find(_context, id);       
            _context.Users.Remove(order);
            await _context.SaveChangesAsync();                
        }

        public static async Task<UserEntity> Find(BaseContext context, int id)
        {
            var user = await context.Users
                                        .Include(u => u.Purchases)   
                                        .ThenInclude(pur=>pur.Orders)
                                        .ThenInclude(o=>o.Product) 
                                        .FirstOrDefaultAsync(u => u.Id == id);

            if(user == null) throw new Exception("User not found");


            return user;
        }
    }
}