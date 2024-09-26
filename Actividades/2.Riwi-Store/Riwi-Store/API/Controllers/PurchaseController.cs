using Microsoft.AspNetCore.Mvc;
using RiwiStore.DTO;

[ApiController]
[Route("api/purchases")]
public class PurchasesController : ControllerBase
{
    private readonly IPurchaseService _PurchaseService;

    /// <summary>
    /// Initializes a new instance of the <see cref="PurchasesController"/> class.
    /// </summary>
    /// <param name="purchaseService">The service to handle purchase operations.</param>
    public PurchasesController(IPurchaseService purchaseService)
    {
        _PurchaseService = purchaseService;
    }

    /// <summary>
    /// Retrieves all purchases.
    /// </summary>
    /// <returns>A list of purchase responses.</returns>
    /// <response code="200">Returns a list of all purchases.</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PurchaseResponse>>> FindAll()
    {        
        return Ok(await _PurchaseService.GetAll());
    }

    /// <summary>
    /// Retrieves a purchase by its ID.
    /// </summary>
    /// <param name="id">The ID of the purchase to retrieve.</param>
    /// <returns>The purchase response, or a 404 error if the purchase is not found.</returns>
    /// <response code="200">Returns the requested purchase.</response>
    /// <response code="404">If the purchase with the specified ID is not found.</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<PurchaseResponse>> FindById(int id)
    {
        var purchase = await _PurchaseService.GetById(id);

        if (purchase == null) return NotFound();        

        return Ok(purchase);
    }

    /// <summary>
    /// Creates a new purchase.
    /// </summary>
    /// <param name="request">The purchase request object containing the details of the new purchase.</param>
    /// <returns>The created purchase response.</returns>
    /// <response code="201">The newly created purchase.</response>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST /api/purchases
    ///     
    ///     {
    ///         "productId": 1,
    ///         "userId": 1,
    ///         "quantity": 2
    ///     }
    /// </remarks>
    [HttpPost]
    public async Task<ActionResult<PurchaseResponse>> Create([FromBody] PurchaseRequest request)
    {           
        var purchaseCreated = await _PurchaseService.Create(request);

        return CreatedAtAction("FindById", new { id = purchaseCreated.Id }, purchaseCreated);
    }

    /// <summary>
    /// Updates an existing purchase by its ID.
    /// </summary>
    /// <param name="id">The ID of the purchase to update.</param>
    /// <param name="request">The purchase request object containing the updated details.</param>
    /// <returns>The updated purchase, or a 404 error if the purchase is not found.</returns>
    /// <response code="200">The updated purchase.</response>
    /// <response code="404">If the purchase with the specified ID is not found.</response>
    /// <remarks>
    /// Sample request:
    /// 
    ///     PUT /api/purchases/1
    ///     
    ///     {
    ///         "productId": 1,
    ///         "userId": 1,
    ///         "quantity": 3
    ///     }
    /// </remarks>
    [HttpPut("{id}")]
    public async Task<ActionResult<PurchaseResponse>> Update(int id, [FromBody] PurchaseRequest request)
    {     
        try
        {                    
            return Ok(await _PurchaseService.Update(id, request));
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Deletes a purchase by its ID.
    /// </summary>
    /// <param name="id">The ID of the purchase to delete.</param>
    /// <response code="204">Indicates that the purchase was successfully deleted.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _PurchaseService.Delete(id);

        return NoContent();
    }
}
