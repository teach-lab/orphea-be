using Microsoft.AspNetCore.Mvc;
using Moq;
using News.Controllers;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Entities.Models.ModelsRespones;
using News.Entities.Models.ModelsUpdate;
using News.Services.ServicesInterface;
using Xunit;

namespace News.Tests.Controllers;

public class CommentsControllerTests
{
    private readonly Mock<ICommentService> _mockService;
    private readonly CommentsController _controller;

    public CommentsControllerTests()
    {
        _mockService = new Mock<ICommentService>();
        _controller = new CommentsController(_mockService.Object);
    }

    [Fact]
    public async Task CreateAsync_CreateNewModel_ReturnsOkResult()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var articleId = Guid.NewGuid();

        var newModel = new CommentCreateModel
        {
            Content = "TestContent",
            UserId = userId.ToString(),
            ArticleId = articleId.ToString()
        };

        var expectedModel = new CommentResponseModel
        {
            Content = "TestContent",
            UserId = (Guid)userId,
            ArticleId = articleId
        };

        _mockService.Setup(service => service.CreateAsync(
            newModel,
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedModel);

        // Act
        var result = await _controller.CreateAsync(newModel, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<CommentResponseModel>(okResult.Value);
        Assert.Equal(expectedModel.Content, returnValue.Content);
        Assert.Equal(expectedModel.ArticleId, returnValue.ArticleId);

        _mockService.Verify(service => service.CreateAsync(
            newModel,
            CancellationToken.None),
            Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_ExistingId_ReturnsOkResult()
    {
        // Arrange
        var commentid = Guid.NewGuid();
        var expectedModel = new CommentModel
        {
            Id = commentid,
            Content = "TestContent",
            LikeCount = 16,
            UserId = Guid.NewGuid(),
            ArticleId = Guid.NewGuid()
        };

        _mockService.Setup(service => service.GetByIdAsync(
            commentid,
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedModel);

        // Act
        var result = await _controller.GetByIdAsync(commentid, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<CommentModel>(okResult.Value);
        Assert.Equal(expectedModel.Id, returnValue.Id);
        Assert.Equal(expectedModel.Content, returnValue.Content);
        Assert.Equal(expectedModel.LikeCount, returnValue.LikeCount);
        Assert.Equal(expectedModel.UserId, returnValue.UserId);
        Assert.Equal(expectedModel.ArticleId, returnValue.ArticleId);

        _mockService.Verify(service => service.GetByIdAsync(
            commentid,
            CancellationToken.None),
            Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ExistingId_ReturnsOkResult()
    {
        // Arrange
        var commentid = Guid.NewGuid();
        var newModel = new CommentUpdateModel
        {
            Content = "TestContent"
        };
        var expectedModel = new CommentResponseModel
        {
            Content = "TestContent",
            UserId = Guid.NewGuid(),
            ArticleId = Guid.NewGuid()
        };

        _mockService.Setup(service => service.UpdateAsync(
            newModel,
            commentid.ToString(),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedModel);

        // Act
        var result = await _controller.UpdateAsync(commentid.ToString(), newModel, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<CommentResponseModel>(okResult.Value);
        Assert.Equal(expectedModel.Content, returnValue.Content);
        Assert.Equal(expectedModel.ArticleId, returnValue.ArticleId);

        _mockService.Verify(service => service.UpdateAsync(
            newModel,
            commentid.ToString(),
            CancellationToken.None),
            Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ExistingId_ReturnsOkResult()
    {
        // Arrange
        var commentid = Guid.NewGuid();

        // Act
        var result = await _controller.DeleteAsync(commentid, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkResult>(result);

        _mockService.Verify(service => service.DeleteAsync(
            commentid,
            CancellationToken.None),
            Times.Once);
    }

    [Fact]
    public void AttributeChecking()
    {
        // Arrange
        var controllerType = typeof(CommentsController);

        // Act
        var apiControllerAttribute = controllerType.GetCustomAttributes(typeof(ApiControllerAttribute), false).FirstOrDefault();
        var routeAttribute = controllerType.GetCustomAttributes(
            typeof(RouteAttribute), false)
            .FirstOrDefault()
            as RouteAttribute;

        // Assert
        Assert.NotNull(apiControllerAttribute);
        Assert.NotNull(routeAttribute);
        Assert.Equal("comments", routeAttribute?.Template);
    }
}