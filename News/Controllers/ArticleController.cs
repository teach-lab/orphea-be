using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Services.ServicesInterface;
using System.Threading;

namespace News.Controllers;

[ApiController]
[Route("articles")]
public class ArticleController : ControllerBase
{    
    private readonly IArticleService _service;

    public ArticleController(DbContext context, IArticleService service)
    {        
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] ArticleCreateModel model,
        CancellationToken cancellationToken
        )
    {
        var createArticle = await _service.CreateAsync(model, cancellationToken);

        return Ok(createArticle);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] Guid id,
        CancellationToken cancellationToken
        )
    {
        var getArticle = await _service.GetByIdAsync(id, cancellationToken);        

        return Ok(getArticle);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] ArticleModel model,
        CancellationToken cancellationToken
        )
    {
        var updateArticle = await _service.UpdateAsync(model, cancellationToken);        

        return Ok(updateArticle);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(
        Guid id,
        CancellationToken cancellationToken
        )
    {
        await _service.DeleteAsync(id, cancellationToken);

        return Ok();
    }
}
