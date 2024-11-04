using Microsoft.AspNetCore.Mvc;
using Moq;
using News.Controllers;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Services.ServicesInterface;
using Xunit;

namespace News.Tests.Controllers;

public class ArticleControllerTests
{
    private readonly Mock<IArticleService> _mockService;
    private readonly ArticleController _controller;

    public ArticleControllerTests()
    {
        _mockService = new Mock<IArticleService>();
        _controller = new ArticleController(_mockService.Object);
    }

    [Fact]
    public async Task CreateAsync_CreateNewModel_ReturnsOkResult()
    {
        // Arrange
        var dataTime = DateTime.Now;
        var publisherId = Guid.NewGuid();
        var newModel = new ArticleCreateModel
        {
            Title = "TestArticle",
            SourceUrl = "https://www.google.com",
            ImageUrl = "https://picsum.photos/id/870/200/300?grayscale&blur=2",
            Description = "TestDescription",
            PublishedAt = dataTime,
            PublisherId = publisherId
        };
        var expectedModel = new ArticleModel
        {
            Id = Guid.NewGuid(),
            Title = "TestArticle",
            SourceUrl = "https://www.google.com",
            ImageUrl = "https://picsum.photos/id/870/200/300?grayscale&blur=2",
            Description = "TestDescription",
            PublishedAt = dataTime,
            PublisherId = publisherId
        };

        _mockService.Setup(service => service.CreateAsync(
            newModel,
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedModel);

        // Act
        var result = await _controller.CreateAsync(newModel, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<ArticleModel>(okResult.Value);
        Assert.Equal(expectedModel.Title, returnValue.Title);
        Assert.Equal(expectedModel.SourceUrl, returnValue.SourceUrl);
        Assert.Equal(expectedModel.ImageUrl, returnValue.ImageUrl);
        Assert.Equal(expectedModel.Description, returnValue.Description);
        Assert.Equal(expectedModel.PublishedAt, returnValue.PublishedAt);
        Assert.Equal(expectedModel.PublisherId, returnValue.PublisherId);
    }

    [Fact]
    public async Task GetByIdAsync_GetArticleById_ReturnsOkResult()
    {
        // Arrange
        var articleId = Guid.NewGuid();
        var newModel = new ArticleModel
        {
            Id = articleId,
            Title = "TestArticle",
            SourceUrl = "https://www.google.com",
            ImageUrl = "https://picsum.photos/id/870/200/300?grayscale&blur=2",
            Description = "TestDescription",
            PublishedAt = DateTime.Now,
            TrustScore = 75,
            PublisherId = Guid.NewGuid(),
            Tags = new List<TagModel>()
        };

        _mockService.Setup(service => service.GetByIdAsync(
            articleId,
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(newModel);

        // Act
        var result = await _controller.GetByIdAsync(articleId, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<ArticleModel>(okResult.Value);
        Assert.Equal(newModel.Title, returnValue.Title);
        Assert.Equal(newModel.SourceUrl, returnValue.SourceUrl);
        Assert.Equal(newModel.ImageUrl, returnValue.ImageUrl);
        Assert.Equal(newModel.Description, returnValue.Description);
        Assert.Equal(newModel.PublishedAt, returnValue.PublishedAt);
        Assert.Equal(newModel.TrustScore, returnValue.TrustScore);
        Assert.Equal(newModel.PublisherId, returnValue.PublisherId);
        Assert.NotNull(returnValue.Tags);
    }

    [Fact]
    public async Task UpdateAsync_UpdateArticle_ReturnsOkResult()
    {
        // Arrange
        var articleId = Guid.NewGuid();
        var newModel = new ArticleModel
        {
            Id = articleId,
            Title = "TestArticle",
            SourceUrl = "https://www.example.com",
            ImageUrl = "https://picsum.photos/id/870/200/300?grayscale&blur=2",
            Description = "Test description",
            PublishedAt = DateTime.Now,
            TrustScore = 80,
            PublisherId = Guid.NewGuid(),
            Tags = new List<TagModel>()
        };

        var updatedArticle = new ArticleModel
        {
            Id = articleId,
            Title = "TestArticleUpdated",
            SourceUrl = "https://www.updatedurl.com",
            ImageUrl = "https://picsum.photos/id/871/200/300?grayscale&blur=2",
            Description = "Updated description",
            PublishedAt = DateTime.Now.AddDays(1),
            TrustScore = 90,
            PublisherId = Guid.NewGuid(),
            Tags = new List<TagModel>()
        };

        _mockService.Setup(service => service.UpdateAsync(
            newModel,
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(updatedArticle);

        // Act
        var result = await _controller.UpdateAsync(newModel, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<ArticleModel>(okResult.Value);
        Assert.Equal(updatedArticle.Id, returnValue.Id);
        Assert.Equal(updatedArticle.Title, returnValue.Title);
        Assert.Equal(updatedArticle.SourceUrl, returnValue.SourceUrl);
        Assert.Equal(updatedArticle.ImageUrl, returnValue.ImageUrl);
        Assert.Equal(updatedArticle.Description, returnValue.Description);
        Assert.Equal(updatedArticle.PublishedAt, returnValue.PublishedAt);
        Assert.Equal(updatedArticle.TrustScore, returnValue.TrustScore);
        Assert.Equal(updatedArticle.PublisherId, returnValue.PublisherId);
        Assert.Equal(updatedArticle.Tags, returnValue.Tags);
    }

    [Fact]
    public async Task DeleteAsync_DeleteArticle_ReturnsOkResult()
    {
        // Arrange
        var articleId = Guid.NewGuid();

        _mockService.Setup(service => service.DeleteAsync(
            articleId,
            It.IsAny<CancellationToken>()));

        // Act
        var result = await _controller.DeleteAsync(articleId, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkResult>(result);

        _mockService.Verify(service => service.DeleteAsync(
            articleId,
            CancellationToken.None),
            Times.Once);
    }

    [Fact]
    public void AttributeChecking()
    {
        // Arrange
        var controllerType = typeof(ArticleController);

        // Act
        var apiControllerAttribute = controllerType.GetCustomAttributes(typeof(ApiControllerAttribute), false).FirstOrDefault();
        var routeAttribute = controllerType.GetCustomAttributes(
            typeof(RouteAttribute), false)
            .FirstOrDefault()
            as RouteAttribute;

        // Assert
        Assert.NotNull(apiControllerAttribute);
        Assert.NotNull(routeAttribute);
        Assert.Equal("articles", routeAttribute?.Template);
    }
}