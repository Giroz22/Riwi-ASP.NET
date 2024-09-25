using Microsoft.AspNetCore.Mvc;
using RiwiStore.DTO;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _OrderService;

    public OrdersController(IOrderService OrderService)
    {
        _OrderService = OrderService;
    }

    //Get Tasks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderResponse>>> FindAll()
    {        
        return Ok(await _OrderService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderResponse>> FindById(int id)
    {
        var user = await _OrderService.GetById(id);

        if(user == null) return NotFound();        

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<OrderResponse>> Create([FromBody] OrderRequest request)
    {           
        var TaskCreated = await _OrderService.Create(request);

        return CreatedAtAction("FindById", new { id = TaskCreated.Id }, TaskCreated);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<OrderResponse>> Update(int id, [FromBody] OrderRequest requets)
    {     
        try
        {                    
            return Ok(await _OrderService.Update(id, requets));
        }
        catch(Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _OrderService.Delete(id);

        return NoContent();
    }
}