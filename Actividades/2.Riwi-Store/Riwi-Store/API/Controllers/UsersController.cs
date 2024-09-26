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

    /// <summary>
    /// Initializes a new instance of the <see cref="UsersController"/> class.
    /// </summary>
    /// <param name="userService">The service to handle user operations.</param>
    /// <param name="validator">The FluentValidator to validate user requests.</param>
    public UsersController(IUserService userService, IValidator<UserRequest> validator)
    {
        _UserService = userService;
        _validator = validator;
    }

    /// <summary>
    /// Retrieves all users.
    /// </summary>
    /// <returns>A list of user responses.</returns>
    /// <response code="200">Returns a list of all users.</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponse>>> FindAll()
    {        
        return Ok(await _UserService.GetAll());
    }

    /// <summary>
    /// Retrieves a user by its ID.
    /// </summary>
    /// <param name="id">The ID of the user to retrieve.</param>
    /// <returns>The user response, or a 404 error if the user is not found.</returns>
    /// <response code="200">Returns the requested user.</response>
    /// <response code="404">If the user with the specified ID is not found.</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> FindById(int id)
    {
        var user = await _UserService.GetById(id);

        if (user == null) return NotFound();        

        return Ok(user);
    }

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="request">The user request object containing the details of the new user.</param>
    /// <returns>The created user response, or validation errors if the request is invalid.</returns>
    /// <response code="201">The newly created user.</response>
    /// <response code="400">If the request is invalid or contains validation errors.</response>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST /api/users
    ///     
    ///     {
    ///         "username": "newuser",
    ///         "email": "newuser@example.com",
    ///         "password": "Password123"
    ///     }
    /// </remarks>
    [HttpPost]
    public async Task<ActionResult<UserResponse>> Create([FromBody] UserRequest request)
    {           
        ValidationResult result = await _validator.ValidateAsync(request);
        if (!result.IsValid)
        {
            result.AddToModelState(ModelState);
            return BadRequest(ModelState);
        } 

        var userCreated = await _UserService.Create(request);

        return CreatedAtAction("FindById", new { id = userCreated.Id }, userCreated);
    }

    /// <summary>
    /// Updates an existing user by its ID.
    /// </summary>
    /// <param name="id">The ID of the user to update.</param>
    /// <param name="request">The user request object containing the updated details.</param>
    /// <returns>The updated user, or a 404 error if the user is not found.</returns>
    /// <response code="200">The updated user.</response>
    /// <response code="400">If the request is invalid or contains validation errors.</response>
    /// <response code="404">If the user with the specified ID is not found.</response>
    /// <remarks>
    /// Sample request:
    /// 
    ///     PUT /api/users/1
    ///     
    ///     {
    ///         "username": "updateduser",
    ///         "email": "updateduser@example.com",
    ///         "password": "NewPassword123"
    ///     }
    /// </remarks>
    [HttpPut("{id}")]
    public async Task<ActionResult<UserResponse>> Update(int id, [FromBody] UserRequest request)
    {     
        try
        {                    
            ValidationResult result = await _validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            } 
                     
            return Ok(await _UserService.Update(id, request));
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Deletes a user by its ID.
    /// </summary>
    /// <param name="id">The ID of the user to delete.</param>
    /// <response code="204">Indicates that the user was successfully deleted.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _UserService.Delete(id);

        return NoContent();
    }
}
