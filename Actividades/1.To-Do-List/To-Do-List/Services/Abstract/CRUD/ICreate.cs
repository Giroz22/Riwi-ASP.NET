using ToDoApi.dtos.request;
using ToDoApi.dtos.response;

public interface ICreate
{
    public Task<TaskResponse> Create(TaskRequest request);
}