using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models;

[ApiController]
[Route("api/[controller]")]
public class NoteController : ControllerBase
{
    private readonly BaseContext _context;

    public NoteController(BaseContext context)
    {
        _context = context;
    }

    //Get Notes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Note>>> FindAll()
    {        
        return await _context.Notes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Note>> FindById(int id)
    {
        var user = await _context.Notes.FindAsync(id);

        if(user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<Note>> Create(Note note)
    {
        _context.Notes.Add(note);
        await _context.SaveChangesAsync();

        return CreatedAtAction("FindById", new { id = note.Id }, note);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Note>> Update(int id, [FromBody] Note newNote)
    {
        if(id != newNote.Id) return BadRequest();        

        var note = await _context.Notes.FindAsync(id);
        if(note == null) return NotFound();

        _context.Entry(note).CurrentValues.SetValues(newNote);
        await _context.SaveChangesAsync();

        return Ok(note);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var note = await _context.Notes.FindAsync(id);
        if(note == null)
        {
            return NotFound();
        }

        note.Deleted = true;
        await _context.SaveChangesAsync();

        return NoContent();
    }

}