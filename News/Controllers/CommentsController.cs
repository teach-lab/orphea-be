using Microsoft.AspNetCore.Mvc;
using News.Services;
using News.Entities.Models;

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

    [HttpGet]
    public async Task<IActionResult> GetCommentById([FromQuery] Guid id)
    {
        var comment = await _service.GetCommentById(id);
        return Ok(comment);
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CommentCreateModel comment)
    {
        var createdComment = await _service.CreateComment(comment);
        return Ok(createdComment);
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> UpdateComment([FromRoute] string id, [FromBody] CommentUpdateModel comment)
    {
        var updatedComment = await _service.UpdateComment(comment, id);
        return Ok(updatedComment);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteComment([FromQuery] Guid id)
    {
        await _service.DeleteComment(id);
        return Ok();
    }
}