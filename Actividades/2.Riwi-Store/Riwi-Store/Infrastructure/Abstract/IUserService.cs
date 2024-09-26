using RiwiStore.API.DTOs;

public interface IUserService :
    IGetAll<UserResponse>,
    IGetById<int, UserResponse>,
    ICreate<UserRequest, UserResponse>,
    IUpdate<int, UserRequest,UserResponse>,
    IDelete<int>
{
    
}