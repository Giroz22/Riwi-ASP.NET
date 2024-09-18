using ToDoApi.dtos.response;

public interface ITaskService : IGetAll, IGetById, ICreate, IUpdate, IDelete {
    Task<TaskResponse> SetTaskToPending(int id);
    Task<TaskResponse> SetTaskToInProgress(int id);
    Task<TaskResponse> MarkAsCompleted(int id);
}