using ToDoApi.Models;

public interface IUpdate
{
    Task<Note> Update(int id, Note note);
}