using RWFormsApi.API.DTOs.Request;
using RWFormsApi.API.DTOs.Response;
using RWFormsApi.Infrastructure.Abstract.CRUD;

namespace RWFormsApi.Infrastructure.Abstract;
public interface IUserService:
    IGetById<string, UserResponse>,
    IGetAll<UserResponse>,
    ICreate<UserRequest, UserResponse>,
    IUpdate<string, UserRequest, UserResponse>,
    IDelete<string>
{
    
}