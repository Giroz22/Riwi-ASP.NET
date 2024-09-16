
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;

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
    public async Task<IActionResult> GetNotes()
    {
        var notes = await _context.Notes.ToListAsync();
        return Ok(notes);
    }
}