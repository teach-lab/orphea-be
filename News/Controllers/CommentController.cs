using Microsoft.AspNetCore.Mvc;
using News.Entities.Models.ModelsCreate;
using News.Entities.Models.ModelsUpdate;
using News.Services.ServicesInterface;

namespace News.Controllers;

[ApiController]
[Route("comment")]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _service;

    public CommentsController(ICommentService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CommentCreateModel comment, CancellationToken cancellationToken)
    {
        if (comment is null)
        {
            return BadRequest("Comment cannot be null.");
        }

        var createdComment = await _service.CreateAsync(comment, cancellationToken);

        return Ok(createdComment);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var commentGet = await _service.GetAsync(id, cancellationToken);
        if (commentGet is null)
        {
            return NotFound($"Comment with ID {id} was not found.");
        }

        return Ok(commentGet);
    }   

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] CommentUpdateModel comment, CancellationToken cancellationToken)
    {
        if (comment is null)
        {
            return BadRequest("Comment update model cannot be null.");
        }        

        var updatedComment = await _service.UpdateAsync(comment, id, cancellationToken);

        return Ok(updatedComment);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        var commentDelete = await _service.GetAsync(id, cancellationToken);
        if (commentDelete is null)
        {
            return NotFound($"Comment with ID {id} was not found.");
        }

        await _service.DeleteAsync(id, cancellationToken);

        return Ok();
    }
}