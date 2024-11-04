using Microsoft.AspNetCore.Mvc;
using Moq;
using News.Controllers;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Services.ServicesInterface;
using Xunit;

namespace News.Tests.Controllers;

public class TagControllerTests
{
    private readonly Mock<ITagService> _mockService;
    private readonly TagController _controller;

    public TagControllerTests()
    {
        _mockService = new Mock<ITagService>();
        _controller = new TagController(_mockService.Object);
    }

    [Fact]
    public async Task CreateAsync_CreateNewModel_ReturnsOkResult()
    {
        // Arrange
        var newModel = new TagCreateModel { Name = "TestTag" };
        var expectedModel = new TagModel { Name = "TestTag" };

        _mockService.Setup(service => service.CreateAsync(
            newModel,
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedModel);

        // Act
        var result = await _controller.CreateAsync(newModel, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<TagModel>(okResult.Value);
        Assert.Equal(expectedModel.Name, returnValue.Name);
    }

    [Fact]
    public async Task GetByIdAsync_GetTagById_ReturnsOkResult()
    {
        // Arrange
        var tagId = Guid.NewGuid();
        var newModel = new TagModel { Id = tagId, Name = "TestTag" };

        _mockService.Setup(service => service.GetByIdAsync(
            tagId,
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(newModel);

        // Act
        var result = await _controller.GetByIdAsync(tagId, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<TagModel>(okResult.Value);
        Assert.Equal(newModel.Name, returnValue.Name);
    }

    [Fact]
    public async Task UpdateAsync_UpdateTag_ReturnsOkResult()
    {
        // Arrange
        var tagId = Guid.NewGuid();
        var newModel = new TagModel { Id = tagId, Name = "TestTag" };
        var updatedTag = new TagModel { Id = tagId, Name = "TestTagUpdate" };

        _mockService.Setup(service => service.UpdateAsync(
            newModel,
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(updatedTag);

        // Act
        var result = await _controller.UpdateAsync(newModel, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<TagModel>(okResult.Value);
        Assert.Equal(updatedTag.Name, returnValue.Name);
    }

    [Fact]
    public async Task DeleteAsync_DeleteTag_ReturnsOkResult()
    {
        // Arrange
        var tagId = Guid.NewGuid();

        // Act
        var result = await _controller.DeleteAsync(tagId, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkResult>(result);

        _mockService.Verify(service => service.DeleteAsync(
            tagId,
            CancellationToken.None),
            Times.Once);
    }

    [Fact]
    public void AttributeChecking()
    {
        // Arrange
        var controllerType = typeof(TagController);

        // Act
        var apiControllerAttribute = controllerType.GetCustomAttributes(typeof(ApiControllerAttribute), false).FirstOrDefault();
        var routeAttribute = controllerType.GetCustomAttributes(
            typeof(RouteAttribute), false)
            .FirstOrDefault()
            as RouteAttribute;

        // Assert
        Assert.NotNull(apiControllerAttribute);
        Assert.NotNull(routeAttribute);
        Assert.Equal("tags", routeAttribute?.Template);
    }
}