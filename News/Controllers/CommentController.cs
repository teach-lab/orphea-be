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
    public async Task<IActionResult> CreateAsync([FromBody] CommentCreateModel comment)
    {
        if (comment is null)
        {
            return BadRequest("Comment cannot be null.");
        }

        var createdComment = await _service.CreateAsync(comment);

        return Ok(createdComment);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        var commentGet = await _service.GetAsync(id);
        if (commentGet is null)
        {
            return NotFound($"Comment with ID {id} was not found.");
        }

        return Ok(commentGet);
    }   

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] CommentUpdateModel comment)
    {
        if (comment is null)
        {
            return BadRequest("Comment update model cannot be null.");
        }        

        var updatedComment = await _service.UpdateAsync(comment, id);

        return Ok(updatedComment);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
    {
        var commentDelete = await _service.GetAsync(id);
        if (commentDelete is null)
        {
            return NotFound($"Comment with ID {id} was not found.");
        }

        await _service.DeleteAsync(id);

        return Ok();
    }
}