using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Entities.Models;
using News.Services.ServicesInterface;

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
    public IActionResult Get([FromQuery] Guid id)
    {
        var result = _service.GetById(id);
        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }


    [HttpPost]
    public IActionResult Add([FromBody] ArticleModel model)
    {
        _service.Add(model);        

        return Created();
    }

    [HttpPut]
    public IActionResult Update([FromBody] ArticleModel model)
    {
        _service.Update(model);       

        return Accepted();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var result = _service.GetById(id);

        if (result is not null)
        {
            _service.Remove(id);
        }

        return NoContent();
    }
}
