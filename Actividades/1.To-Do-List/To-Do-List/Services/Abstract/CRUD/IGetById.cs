using ToDoApi.dtos.response;

public interface IGetById
{
    Task<TaskResponse?> GetById(int id);
}