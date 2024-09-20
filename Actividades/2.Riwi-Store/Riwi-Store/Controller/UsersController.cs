using Microsoft.AspNetCore.Mvc;
using RiwiStore.DTO;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _UserService;

    public UsersController(IUserService UserService)
    {
        _UserService = UserService;
    }

    //Get Tasks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponse>>> FindAll()
    {        
        return Ok(await _UserService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> FindById(int id)
    {
        var user = await _UserService.GetById(id);

        if(user == null) return NotFound();        

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> Create([FromBody] UserRequest request)
    {           
        var TaskCreated = await _UserService.Create(request);

        return CreatedAtAction("FindById", new { id = TaskCreated.Id }, TaskCreated);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserResponse>> Update(int id, [FromBody] UserRequest requets)
    {     
        try
        {                    
            return Ok(await _UserService.Update(id, requets));
        }
        catch(Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _UserService.Delete(id);

        return NoContent();
    }
}