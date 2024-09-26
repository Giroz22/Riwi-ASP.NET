using Microsoft.AspNetCore.Mvc;
using RiwiStore.DTO;

[ApiController]
[Route("api/purchases")]
public class PurchasesController : ControllerBase
{
    private readonly IPurchaseService _PurchaseService;

    public PurchasesController(IPurchaseService PurchaseService)
    {
        _PurchaseService = PurchaseService;
    }

    //Get Tasks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PurchaseResponse>>> FindAll()
    {        
        return Ok(await _PurchaseService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PurchaseResponse>> FindById(int id)
    {
        var purchase = await _PurchaseService.GetById(id);

        if(purchase == null) return NotFound();        

        return Ok(purchase);
    }

    [HttpPost]
    public async Task<ActionResult<PurchaseResponse>> Create([FromBody] PurchaseRequest request)
    {           
        var TaskCreated = await _PurchaseService.Create(request);

        return CreatedAtAction("FindById", new { id = TaskCreated.Id }, TaskCreated);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PurchaseResponse>> Update(int id, [FromBody] PurchaseRequest requets)
    {     
        try
        {                    
            return Ok(await _PurchaseService.Update(id, requets));
        }
        catch(Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _PurchaseService.Delete(id);

        return NoContent();
    }
}