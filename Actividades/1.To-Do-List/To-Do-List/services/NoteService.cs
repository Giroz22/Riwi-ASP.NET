using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models;

class NoteService : INoteService
{

    private readonly BaseContext _context;

    public NoteService(BaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Note>> GetAll()
    {
        return await _context.Notes.ToListAsync();
    }

    public async Task<Note?> GetById(int id)
    {
        var user = await _context.Notes.FindAsync(id);

        return user;
    }

    public async Task<Note> Create(Note note)
    {
        _context.Notes.Add(note);
        await _context.SaveChangesAsync();

        return note;
    }    

    public async Task<Note> Update(int id, Note note)
    {
        _context.Entry(note).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return note;
    }

    public async Task Delete(int id)
    {
        var note = await _context.Notes.FindAsync(id);
        if(note != null)
        {
            note.Deleted = true;
            await _context.SaveChangesAsync();
        }        
    }
}