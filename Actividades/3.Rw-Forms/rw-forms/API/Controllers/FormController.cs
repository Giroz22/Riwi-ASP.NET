using Microsoft.AspNetCore.Mvc;
using RWFormsApi.API.DTOs.Request;
using RWFormsApi.API.DTOs.Response;
using RWFormsApi.Infrastructure.Abstract;

[ApiController]
[Route("api/Forms")]
public class FormController : ControllerBase
{
    private readonly IFormService _formService;

    public FormController(IFormService formService)
    {
        _formService = formService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FormResponse>>> FindAll()
    {
        return Ok(await _formService.GetAll());
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<FormResponse>> FindById(string id)
    {
        return Ok(await _formService.GetById(id));
    }

    [HttpPost]
    public async Task<ActionResult<FormResponse>> Create(FormRequest request)
    {
        FormResponse response = await _formService.Create(request);
        return CreatedAtAction(nameof(FindById), new {id = response.Id}, response);
    }

    [HttpPut]
    public async Task<ActionResult<FormResponse>> Update(string id, FormRequest request)
    {
        return  Ok(await _formService.Update(id, request));
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<ActionResult> Delete(string id)
    {
        await _formService.Delete(id);
        return NoContent();
    }
}