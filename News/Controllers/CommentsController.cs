using Microsoft.AspNetCore.Mvc;
using News.Entities.Models.ModelsCreate;
using News.Entities.Models.ModelsUpdate;
using News.Services.ServicesInterface;

namespace News.Controllers;

[ApiController]
[Route("comments")]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _service;

    public CommentsController(ICommentService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var comment = await _service.GetByIdAsync(id, cancellationToken);

        return Ok(comment);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CommentCreateModel comment, CancellationToken cancellationToken)
    {
        var createdComment = await _service.CreateAsync(comment, cancellationToken);

        return Ok(createdComment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] CommentUpdateModel comment, CancellationToken cancellationToken)
    {
        var updatedComment = await _service.UpdateAsync(comment, id, cancellationToken);

        return Ok(updatedComment);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(id, cancellationToken);

        return Ok();
    }
}