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

    [HttpDelete]
    public async Task<IActionResult> DeleteComment([FromQuery] Guid id)
    {
        await _service.DeleteComment(id);
        return Ok();
    }
}