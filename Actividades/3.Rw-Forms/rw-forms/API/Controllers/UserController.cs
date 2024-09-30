using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RWFormsApi.API.DTOs.Request;
using RWFormsApi.API.DTOs.Response;
using RWFormsApi.Infrastructure.Abstract;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IValidator<UserRequest> _userValidator;

    public UserController(IUserService userService, IValidator<UserRequest> userValidator)
    {
        _userService = userService;
        _userValidator = userValidator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponse>>> FindAll()
    {        
        return Ok(await _userService.GetAll());
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<UserResponse>> FindOne(string id)
    {        
        return Ok(await _userService.GetById(id));        
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> Create([FromBody] UserRequest request)
    {
        _userValidator.ValidateAndThrow(request);
        var response = await _userService.Create(request);
        return CreatedAtAction(nameof(FindOne), new { id = response.Id} , response);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<ActionResult<UserResponse>> Update(string id, [FromBody] UserRequest request)
    {
        _userValidator.ValidateAndThrow(request);
        return Ok(await _userService.Update(id, request));
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<ActionResult> Delete(string id)
    {
        await _userService.Delete(id);
        return NoContent();
    }

}