using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Services.ServicesInterface;


namespace News.Controllers;

[ApiController]
[Route("tags")]
public class TagController : Controller
{
    private readonly ITagService _service;
    public TagController(ITagService service)
    {            
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] TagCreateModel model,
        CancellationToken cancellationToken
        )
    {
        if (model is null)
        {
            return BadRequest("Tag model cannot be null.");
        }

        var createTag = await _service.CreateAsync(model, cancellationToken);

        return Ok(createTag);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] Guid id,
        CancellationToken cancellationToken
        )
    {
        var getTag = await _service.GetByIdAsync(id, cancellationToken);
        if (getTag is null)
        {
            return NotFound($"Tag with ID {id} was not found.");
        }

        return Ok(getTag);
    }    

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] TagModel model,
        CancellationToken cancellationToken
        )
    {
        if (model is null)
        {
            return BadRequest("Tag model cannot be null.");
        }

        var existingTag = await _service.GetByIdAsync(model.Id, cancellationToken);
        if (existingTag is null)
        {
            return NotFound($"Tag with ID {model.Id} was not found.");
        }

        var updateTag = await _service.UpdateAsync(model, cancellationToken);       

        return Ok(updateTag);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var deleteTag = await _service.GetByIdAsync(id, cancellationToken);
        if (deleteTag is null)
        {
            return NotFound($"Tag with ID {id} was not found.");
        }

        await _service.DeleteAsync(id, cancellationToken);

        return Ok(deleteTag);
    }
}
