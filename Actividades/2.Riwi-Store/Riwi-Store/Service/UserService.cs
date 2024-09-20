using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RiwiStore.Data;
using RiwiStore.DTO;
using RiwiStore.Model;

namespace RiwiStore.Services
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
            var Users = await _context.Users.ToListAsync();

            return _mapper.Map<IEnumerable<UserResponse>>(Users);
        }

        public async Task<UserResponse> GetById(int id)
        {
            var order = await find(id);

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
            var order = await find(id);

            _mapper.Map(request, order);

            _context.Users.Update(order);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserResponse>(order);
        }

        public async Task Delete(int id)
        {
            var order = await find(id);       
            _context.Users.Remove(order);
            await _context.SaveChangesAsync();                
        }

        private async Task<UserEntity> find(int id)
        {
            var order = await _context.Users.FindAsync(id);

            if(order == null) throw new Exception("User not found");

            return order;
        }
    }
}