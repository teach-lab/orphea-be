using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Entities.Models;
using News.Services.ServicesInterface;
using System.Threading;

namespace News.Controllers;

[ApiController]
[Route("article")]
public class ArticleController : ControllerBase
{    
    private readonly IArticleService _service;
    public ArticleController(DbContext context, IArticleService service)
    {        
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await _service.GetById(id, cancellationToken);        

        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ArticleCreateModel model, CancellationToken cancellationToken)
    {
        var result = await _service.Add(model, cancellationToken);        

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ArticleModel model, CancellationToken cancellationToken)
    {
        var result = await _service.Update(model, cancellationToken);       

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await _service.GetById(id, cancellationToken);
        return Ok(result);
    }
}
