using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Services.ServicesInterface;

namespace News.Controllers;

[ApiController]
[Route("publisher")]
public class PublisherController : Controller
{        
    private readonly IPublisherService _service;

    public PublisherController(IPublisherService service)
    {            
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] PublisherCreateModel model, CancellationToken cancellationToken)
    {
        if (model is null)
        {
            return BadRequest("Publisher model cannot be null.");
        }

        var createPublisher = await _service.CreateAsync(model, cancellationToken);

        return Ok(createPublisher);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var getPublisher = await _service.GetAsync(id, cancellationToken);
        if (getPublisher is null)
        {
            return NotFound($"Publisher with ID {id} was not found.");
        }

        return Ok(getPublisher);
    }    

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] PublisherModel model, CancellationToken cancellationToken)
    {
        if (model is null)
        {
            return BadRequest("Publisher model cannot be null.");
        }

        var existingPublisher = await _service.GetAsync(model.Id, cancellationToken);
        if (existingPublisher is null)
        {
            return NotFound($"Publisher with ID {model.Id} was not found.");
        }

        var updatePublisher = await _service.UpdateAsync(model, cancellationToken);

        return Ok(updatePublisher);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var deletePublisher = await _service.GetAsync(id, cancellationToken);
        if (deletePublisher is null)
        {
            return NotFound($"Publisher with ID {id} was not found.");
        }

        await _service.DeleteAsync(id, cancellationToken);

        return Ok(deletePublisher);
    }
}
