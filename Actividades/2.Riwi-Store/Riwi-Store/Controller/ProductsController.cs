using Microsoft.AspNetCore.Mvc;
using RiwiStore.DTO;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{

    private readonly IProductService _ProductService;

    public ProductsController(IProductService productService)
    {
        _ProductService = productService;
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
        var TaskCreated = await _ProductService.Create(request);

        return CreatedAtAction("FindById", new { id = TaskCreated.Id }, TaskCreated);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductResponse>> Update(int id, [FromBody] ProductRequest requets)
    {     
        try
        {                    
            return Ok(await _ProductService.Update(id, requets));
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
