using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Entities.Models;
using News.Services.ServicesInterface;

namespace News.Controllers;

[ApiController]
[Route("publisher")]
public class PublisherController : Controller
{        
    private readonly IPublisherService _service;

    public PublisherController(IPublisherService service)
    {            
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await _service.GetById(id);
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PublisherModel model)
    {
        var result = await _service.Add(model);            

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] PublisherModel model)
    {
        var result = await _service.Update(model);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _service.GetById(id);

        return Ok(result);
    }
}
