using ToDoApi.Models;

public interface ICreate
{
    public Task<Note> Create(Note note);
}