using Microsoft.AspNetCore.Mvc;
using News.Services.ServicesSourceNews;

namespace News.Controllers;

[ApiController]
[Route("{xPublisherTypeService}")]
public class PublishersApiController : ControllerBase
{
    private readonly XPublisherFactoryService _factoryService;

    public PublishersApiController(XPublisherFactoryService factoryService)
    {
        _factoryService = factoryService;
    }

    [HttpGet("articles")]
    public async Task<IActionResult> GetAllArticlesAsync(
        [FromRoute] string xPublisherTypeService,
        CancellationToken cancellationToken)
    {
        var serviceType = Enum.GetValues<XPublisherTypeService>()
            .FirstOrDefault(type => type.GetDisplayName().Equals(xPublisherTypeService, StringComparison.OrdinalIgnoreCase));

        var service = _factoryService.GetService(serviceType);
        var data = await service.GetAllAsync(cancellationToken);
        return Ok(data);
    }

    [HttpGet("articles/{id}")]
    public async Task<IActionResult> GetSingleArticleAsync(
        [FromRoute] string xPublisherTypeService,
        [FromRoute] string id,
        CancellationToken cancellationToken)
    {
        var serviceType = Enum.GetValues<XPublisherTypeService>()
            .FirstOrDefault(type => type.GetDisplayName().Equals(xPublisherTypeService, StringComparison.OrdinalIgnoreCase));

        var service = _factoryService.GetService(serviceType);
        var data = await service.GetAsync(id, cancellationToken);
        return Ok(data);
    }
}