using Microsoft.AspNetCore.Mvc;
using Moq;
using News.Controllers;
using News.Entities.Models;
using News.Services.ServicesInterface;
using Xunit;

namespace News.Tests.Controllers;

public class GoogleAuthControllerTests
{
    private readonly Mock<IGoogleAuthService> _mockGoogleAuthService;
    private readonly GoogleAuthController _controller;

    public GoogleAuthControllerTests()
    {
        _mockGoogleAuthService = new Mock<IGoogleAuthService>();
        _controller = new GoogleAuthController(_mockGoogleAuthService.Object);
    }

    [Fact]
    public async Task LoginAsync_ValidGoogleAccessToken_ReturnsOkResult()
    {
        // Arrange
        var googleAccess = "valid_access_token";
        var expectedToken = new TokensPair
        {
            Access = "new_generated_jwt_token",
            Refresh = "generated_refresh_token"
        };

        _mockGoogleAuthService.Setup(service => service.LoginGoogleAsync(
            googleAccess,
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedToken);

        // Act
        var result = await _controller.LoginAsync(googleAccess, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<TokensPair>(okResult.Value);
        Assert.Equal(expectedToken, okResult.Value);
        Assert.Equal(expectedToken.Access, returnValue.Access);
        Assert.Equal(expectedToken.Refresh, returnValue.Refresh);

        _mockGoogleAuthService.Verify(service => service.LoginGoogleAsync(
            googleAccess,
            It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public void AttributeChecking()
    {
        // Arrange
        var controllerType = typeof(GoogleAuthController);

        // Act
        var apiControllerAttribute = controllerType.GetCustomAttributes(
            typeof(ApiControllerAttribute), false).FirstOrDefault();
        var routeAttribute = controllerType.GetCustomAttributes(
            typeof(RouteAttribute), false)
            .FirstOrDefault()
            as RouteAttribute;

        // Assert
        Assert.NotNull(apiControllerAttribute);
        Assert.NotNull(routeAttribute);
        Assert.Equal("google-auth", routeAttribute?.Template);
    }
}