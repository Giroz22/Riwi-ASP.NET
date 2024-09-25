using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RiwiStore.DTO;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{

    private readonly IProductService _ProductService;
    private readonly IValidator<ProductRequest> _validator;

    public ProductsController(IProductService productService, IValidator<ProductRequest> validator)
    {
        _ProductService = productService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> FindAll()
    {        
        return Ok(await _ProductService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse>> FindById(int id)
    {
        var user = await _ProductService.GetById(id);

        if(user == null) return NotFound();        

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<ProductResponse>> Create([FromBody] ProductRequest request)
    {           
        ValidationResult result = await _validator.ValidateAsync(request);
        if(!result.IsValid){
            result.AddToModelState(ModelState);
            return BadRequest(ModelState);
        } 

        var TaskCreated = await _ProductService.Create(request);

        return CreatedAtAction("FindById", new { id = TaskCreated.Id }, TaskCreated);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductResponse>> Update(int id, [FromBody] ProductRequest request)
    {     
        try
        {         
            ValidationResult result = await _validator.ValidateAsync(request);
            if(!result.IsValid){
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            } 
            
            return Ok(await _ProductService.Update(id, request));
        }
        catch(Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _ProductService.Delete(id);

        return NoContent();
    }

}
