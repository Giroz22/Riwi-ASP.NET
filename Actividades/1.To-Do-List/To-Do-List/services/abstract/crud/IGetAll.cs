using ToDoApi.Models;

public interface IGetAll
{
    public Task<IEnumerable<Note>> GetAll();
}