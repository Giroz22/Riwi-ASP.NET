using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;

[ApiController]
[Route("api/[controller]")]
public class NoteController : ControllerBase
{
    private readonly INoteService _noteService;

    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }

    //Get Notes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Note>>> FindAll()
    {        
        return Ok(await _noteService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Note>> FindById(int id)
    {
        var user = await _noteService.GetById(id);

        if(user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<Note>> Create(Note note)
    {        
        var noteCreated = await _noteService.Create(note);

        return CreatedAtAction("FindById", new { id = noteCreated.Id }, noteCreated);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Note>> Update(int id, [FromBody] Note newNote)
    {
        if(id != newNote.Id) return BadRequest();        

        return Ok(await _noteService.Update(id, newNote));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _noteService.Delete(id);

        return NoContent();
    }

}