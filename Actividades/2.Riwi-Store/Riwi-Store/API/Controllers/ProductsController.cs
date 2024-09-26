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

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductsController"/> class.
    /// </summary>
    /// <param name="productService">The service to handle product operations.</param>
    /// <param name="validator">The FluentValidator to validate product requests.</param>
    public ProductsController(IProductService productService, IValidator<ProductRequest> validator)
    {
        _ProductService = productService;
        _validator = validator;
    }

    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>A list of product responses.</returns>
    /// <response code="200">Returns a list of all products.</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> FindAll()
    {        
        return Ok(await _ProductService.GetAll());
    }

    /// <summary>
    /// Retrieves a product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product to retrieve.</param>
    /// <returns>The product response, or a 404 error if the product is not found.</returns>
    /// <response code="200">Returns the requested product.</response>
    /// <response code="404">If the product with the specified ID is not found.</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse>> FindById(int id)
    {
        var product = await _ProductService.GetById(id);

        if (product == null) return NotFound();

        return Ok(product);
    }

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="request">The product request object containing the details of the new product.</param>
    /// <returns>The created product response, or validation errors if the request is invalid.</returns>
    /// <response code="201">The newly created product.</response>
    /// <response code="400">If the request is invalid or contains validation errors.</response>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST /api/products
    ///     {
    ///         "name": "New Product",
    ///         "description": "Description of the new product.",
    ///         "price": 19.99
    ///     }
    /// </remarks>   
    [HttpPost]
    public async Task<ActionResult<ProductResponse>> Create([FromBody] ProductRequest request)
    {           
        ValidationResult result = await _validator.ValidateAsync(request);
        if (!result.IsValid)
        {
            result.AddToModelState(ModelState);
            return BadRequest(ModelState);
        } 

        var productCreated = await _ProductService.Create(request);

        return CreatedAtAction("FindById", new { id = productCreated.Id }, productCreated);
    }

    /// <summary>
    /// Updates an existing product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product to update.</param>
    /// <param name="request">The product request object containing the updated details.</param>
    /// <returns>The updated product, or a 404 error if the product is not found.</returns>
    /// <response code="200">The updated product.</response>
    /// <response code="400">If the request is invalid or contains validation errors.</response>
    /// <response code="404">If the product with the specified ID is not found.</response>
    /// <remarks>
    /// Sample request:
    /// 
    ///     PUT /api/products/1
    ///     
    ///     {
    ///         "name": "Updated Product",
    ///         "description": "Updated description of the product.",
    ///         "price": 24.99
    ///     }
    /// </remarks>
    [HttpPut("{id}")]
    public async Task<ActionResult<ProductResponse>> Update(int id, [FromBody] ProductRequest request)
    {     
        try
        {         
            ValidationResult result = await _validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return BadRequest(ModelState);
            } 
            
            return Ok(await _ProductService.Update(id, request));
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Deletes a product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product to delete.</param>
    /// <response code="204">Indicates that the product was successfully deleted.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _ProductService.Delete(id);

        return NoContent();
    }
}
