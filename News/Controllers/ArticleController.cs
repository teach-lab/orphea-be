using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Entities.Models;
using News.Services.ServicesInterface;

namespace News.Controllers;

[ApiController]
[Route("article")]
public class ArticleController : ControllerBase
{
    private readonly DbContext _context;
    private readonly IArticleService _service;
    public ArticleController(DbContext context, IArticleService service)
    {
        _context = context;
        _service = service;
    }

    [HttpGet]
    public IActionResult GetFilmById([FromQuery] Guid id)
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
        _context.SaveChanges();

        return Created();
    }

    [HttpPut]
    public IActionResult UpdateFilm([FromBody] ArticleModel model)
    {
        _service.Update(model);
        _context.SaveChanges();

        return Accepted();
    }

    [HttpDelete]
    public IActionResult DeleteFilmById(Guid id)
    {
        var result = _service.GetById(id);

        if (result is not null)
        {
            _service.Remove(result!);
            _context.SaveChanges();
        }

        return NoContent();
    }
}
