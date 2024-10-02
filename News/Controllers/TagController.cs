using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Entities.Models;
using News.Services.ServicesInterface;


namespace News.Controllers;

[ApiController]
[Route("tag")]
public class TagController : Controller
{
    private readonly ITagService _service;
    public TagController(ITagService service)
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
    public IActionResult Add([FromBody] TagModel model)
    {
        _service.Add(model);

        return Created();
    }

    [HttpPut]
    public IActionResult Update([FromBody] TagModel model)
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
