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
        var createdComment = await _service.CreateAsync(comment);

        return Ok(createdComment);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        var comment = await _service.GetAsync(id);

        return Ok(comment);
    }   

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] CommentUpdateModel comment)
    {
        var updatedComment = await _service.UpdateAsync(comment, id);

        return Ok(updatedComment);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
    {
        await _service.DeleteAsync(id);

        return Ok();
    }
}