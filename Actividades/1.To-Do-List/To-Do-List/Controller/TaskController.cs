using Microsoft.AspNetCore.Mvc;
using ToDoApi.dtos.request;
using ToDoApi.dtos.response;

[ApiController]
[Route("api/tasks")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _TaskService;

    public TaskController(ITaskService TaskService)
    {
        _TaskService = TaskService;
    }

    //Get Tasks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskResponse>>> FindAll()
    {        
        return Ok(await _TaskService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskResponse>> FindById(int id)
    {
        var user = await _TaskService.GetById(id);

        if(user == null) return NotFound();        

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<TaskResponse>> Create([FromBody] TaskRequest request)
    {           
        var TaskCreated = await _TaskService.Create(request);

        return CreatedAtAction("FindById", new { id = TaskCreated.Id }, TaskCreated);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TaskResponse>> Update(int id, [FromBody] TaskRequest requets)
    {     
        try
        {                    
            return Ok(await _TaskService.Update(id, requets));
        }
        catch(Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _TaskService.Delete(id);

        return NoContent();
    }

    [HttpGet("{id}/pending")]
    public async Task<ActionResult<TaskResponse>> SetToPending(int id)
    {
        try
        {
            return Ok(await _TaskService.SetTaskToPending(id));
        }
        catch(Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
        
    }

    [HttpGet("{id}/inprogress")]
    public async Task<ActionResult<TaskResponse>> SetToInProgress(int id)
    {
        try
        {
            return Ok(await _TaskService.SetTaskToInProgress(id));
        }
        catch(Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
        
    }

    [HttpGet("{id}/complete")]
    public async Task<ActionResult<TaskResponse>> CompleteTask(int id)
    {
        try
        {
            return Ok(await _TaskService.MarkAsCompleted(id));
        }
        catch(Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }        
    }

}