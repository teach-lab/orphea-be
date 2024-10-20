using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Services.ServicesInterface;

namespace News.Controllers;

[ApiController]
[Route("publishers")]
public class PublisherController : Controller
{
    private readonly IPublisherService _service;

    public PublisherController(IPublisherService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] PublisherCreateModel model,
        CancellationToken cancellationToken
        )
    {
        var createPublisher = await _service.CreateAsync(model, cancellationToken);

        return Ok(createPublisher);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] Guid id,
        CancellationToken cancellationToken
        )
    {
        var getPublisher = await _service.GetByIdAsync(id, cancellationToken);

        return Ok(getPublisher);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] PublisherModel model,
        CancellationToken cancellationToken)
    {
        var updatePublisher = await _service.UpdateAsync(model, cancellationToken);

        return Ok(updatePublisher);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(id, cancellationToken);

        return Ok();
    }
}