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

        return Ok(getTag);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] TagModel model,
        CancellationToken cancellationToken
        )
    {
        var updateTag = await _service.UpdateAsync(model, cancellationToken);

        return Ok(updateTag);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(id, cancellationToken);

        return Ok();
    }
}