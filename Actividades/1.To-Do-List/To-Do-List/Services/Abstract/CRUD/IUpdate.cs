using ToDoApi.dtos.request;
using ToDoApi.dtos.response;

public interface IUpdate
{
    Task<TaskResponse> Update(int id, TaskRequest request);
}