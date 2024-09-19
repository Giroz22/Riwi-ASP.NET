using ToDoApi.dtos.response;

public interface IGetAll
{
    public Task<IEnumerable<TaskResponse>> GetAll();
}