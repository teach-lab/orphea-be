using Microsoft.AspNetCore.Mvc;
using Moq;
using News.Controllers;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Services.ServicesInterface;
using Xunit;

namespace News.Tests.Controllers;

public class PublisherControllerTests
{
    private readonly Mock<IPublisherService> _mockService;
    private readonly PublisherController _controller;

    public PublisherControllerTests()
    {
        _mockService = new Mock<IPublisherService>();
        _controller = new PublisherController(_mockService.Object);
    }

    [Fact]
    public async Task CreateAsync_CreateNewModel_ReturnsOkResult()
    {
        // Arrange
        var newModel = new PublisherCreateModel { Name = "TestPublisher", TrustScore = 69 };
        var expectedModel = new PublisherModel { Name = "TestPublisher", TrustScore = 69 };

        _mockService.Setup(service =>
            service.CreateAsync(newModel, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedModel);

        // Act
        var result = await _controller.CreateAsync(newModel, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<PublisherModel>(okResult.Value);
        Assert.Equal(expectedModel.Name, returnValue.Name);
        Assert.Equal(expectedModel.TrustScore, returnValue.TrustScore);
    }

    [Fact]
    public async Task GetByIdAsync_GetPublisherById_ReturnsOkResult()
    {
        // Arrange
        var publisherId = Guid.NewGuid();
        var newModel = new PublisherModel { Id = publisherId, Name = "TestPublisher", TrustScore = 12 };

        _mockService.Setup(service =>
            service.GetByIdAsync(publisherId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(newModel);

        // Act
        var result = await _controller.GetByIdAsync(publisherId, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<PublisherModel>(okResult.Value);
        Assert.Equal(newModel.Name, returnValue.Name);
        Assert.Equal(newModel.TrustScore, returnValue.TrustScore);
    }

    [Fact]
    public async Task UpdateAsync_UpdatePublisher_ReturnsOkResult()
    {
        // Arrange
        var newModel = new PublisherModel { Id = Guid.NewGuid(), Name = "TestPublisher", TrustScore = 14 };
        var updatedPublisher = new PublisherModel { Id = newModel.Id, Name = "TestPublisher", TrustScore = 14 };

        _mockService.Setup(service =>
            service.UpdateAsync(newModel, It.IsAny<CancellationToken>()))
            .ReturnsAsync(updatedPublisher);

        // Act
        var result = await _controller.UpdateAsync(newModel, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<PublisherModel>(okResult.Value);
        Assert.Equal(updatedPublisher.Name, returnValue.Name);
        Assert.Equal(updatedPublisher.TrustScore, returnValue.TrustScore);
    }

    [Fact]
    public async Task DeleteAsync_DeletePublisher_ReturnsOkResult()
    {
        // Arrange
        var publisherId = Guid.NewGuid();

        // Act
        var result = await _controller.DeleteAsync(publisherId, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkResult>(result);

        _mockService.Verify(service => service.DeleteAsync(
            publisherId,
            CancellationToken.None),
            Times.Once);
    }

    [Fact]
    public void AttributeChecking()
    {
        // Arrange
        var controllerType = typeof(PublisherController);

        // Act
        var apiControllerAttribute = controllerType.GetCustomAttributes(typeof(ApiControllerAttribute), false).FirstOrDefault();
        var routeAttribute = controllerType.GetCustomAttributes(
            typeof(RouteAttribute), false)
            .FirstOrDefault()
            as RouteAttribute;

        // Assert
        Assert.NotNull(apiControllerAttribute);
        Assert.NotNull(routeAttribute);
        Assert.Equal("publishers", routeAttribute?.Template);
    }
}