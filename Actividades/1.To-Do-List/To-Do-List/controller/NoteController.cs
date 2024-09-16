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
    public async Task<ActionResult<IEnumerable<Note>>> Index()
    {        
        return await _context.Notes.ToListAsync();
    }
}