using ToDoApi.Models;

public interface IGetById
{
    Task<Note?> GetById(int id);
}