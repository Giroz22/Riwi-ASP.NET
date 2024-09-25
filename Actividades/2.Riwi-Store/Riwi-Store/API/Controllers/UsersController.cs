using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RiwiStore.DTO;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _UserService;
    private readonly IValidator<UserRequest> _validator;

    public UsersController(IUserService UserService, IValidator<UserRequest> validator)
    {
        _UserService = UserService;
        _validator = validator;
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
        ValidationResult result = await _validator.ValidateAsync(request);
        if(!result.IsValid){
            result.AddToModelState(ModelState);
            return BadRequest(ModelState);
        } 

        var TaskCreated = await _UserService.Create(request);

        return CreatedAtAction("FindById", new { id = TaskCreated.Id }, TaskCreated);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserResponse>> Update(int id, [FromBody] UserRequest request)
    {     
        try
        {                    
            ValidationResult result = await _validator.ValidateAsync(request);
            if(!result.IsValid){
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            } 
                     
            return Ok(await _UserService.Update(id, request));
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