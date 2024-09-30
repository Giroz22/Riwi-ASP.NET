using AutoMapper;
using MongoDB.Driver;
using RWFormsApi.API.DTOs.Request;
using RWFormsApi.API.DTOs.Response;
using RWFormsApi.Domain.Entities;
using RWFormsApi.Infrastructure.Abstract;
using RWFormsApi.Util.Exceptions;

namespace RWFormsApi.Infrastructure.Services;
class UserService : IUserService
{
    private readonly IMongoCollection<UserEntity> _userCollection;
    private readonly IMapper _mapper;

    public UserService(IMongoDatabase database, IMapper mapper)
    {
        _userCollection = database.GetCollection<UserEntity>("Users");
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserResponse>> GetAll()
    {
        List<UserEntity> users = await _userCollection.Find(user => true).ToListAsync();
        return _mapper.Map<List<UserResponse>>(users);
    }

    public async Task<UserResponse> GetById(string id)
    {
        UserEntity user = await FindUser(_userCollection, id);
        return _mapper.Map<UserResponse>(user);
    }

    public async Task<UserResponse> Create(UserRequest request)
    {
        UserEntity user = _mapper.Map<UserEntity>(request);

        await _userCollection.InsertOneAsync(user);

        return _mapper.Map<UserResponse>(user);
    }

    public async Task<UserResponse> Update(string id, UserRequest request)
    {
        UserEntity user = await FindUser(_userCollection, id);
        _mapper.Map(request, user);

        await _userCollection.ReplaceOneAsync(
            u => u.Id == id,
            user
        );

        return _mapper.Map<UserResponse>(user);
    }

    public async Task Delete(string id)
    {
        UserEntity user = await FindUser(_userCollection, id);
        await _userCollection.DeleteOneAsync(u => u == user);
    }

    public static async Task<UserEntity> FindUser(IMongoCollection<UserEntity> userCollection, string id)
    {
        return await userCollection.Find(u => u.Id == id).FirstOrDefaultAsync() ??
        throw new IdNotFoundException("User", id);
    }
}