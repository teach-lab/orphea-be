using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Entities.Models;
using News.Services.ServicesInterface;


namespace News.Controllers;

[ApiController]
[Route("tag")]
public class TagController : Controller
{
    private readonly ITagService _service;
    public TagController(ITagService service)
    {            
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await _service.GetById(id, cancellationToken);
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] TagModel model, CancellationToken cancellationToken)
    {
        var result = await _service.Add(model, cancellationToken);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TagModel model, CancellationToken cancellationToken)
    {
        var result = await _service.Update(model, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await _service.GetById(id, cancellationToken);
        return Ok(result);
    }
}
