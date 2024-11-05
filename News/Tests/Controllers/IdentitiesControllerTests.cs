using Microsoft.AspNetCore.Mvc;
using Moq;
using News.Controllers;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Services.ServicesInterface;
using Xunit;

namespace News.Tests.Controllers;

public class IdentitiesControllerTests
{
    private readonly Mock<IIdentityService> _mockService;
    private readonly Mock<ITokenService> _mockTokenService;
    private readonly IdentitiesController _controller;

    public IdentitiesControllerTests()
    {
        _mockService = new Mock<IIdentityService>();
        _mockTokenService = new Mock<ITokenService>();
        _controller = new IdentitiesController(_mockService.Object, _mockTokenService.Object);
    }

    [Fact]
    public async Task LoginAsyncLoginReturnsOkResult()
    {
        // Arrange
        var login = new LoginModel
        {
            Login = "testuser",
            Password = "password123"
        };

        var tokensPair = new TokensPair
        {
            Access = "access_token",
            Refresh = "refresh_token"
        };

        _mockService.Setup(service => service.LoginAsync(
            login,
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(tokensPair);

        // Act
        var result = await _controller.LoginAsync(login, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<TokensPair>(okResult.Value);
        Assert.Equal(tokensPair.Access, returnValue.Access);
        Assert.Equal(tokensPair.Refresh, returnValue.Refresh);

        _mockService.Verify(service => service.LoginAsync(
            login,
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task RegisterAsync_Register_ReturnsOkResult()
    {
        // Arrange
        var newUser = new UserCreateModel
        {
            FirstName = "nameTest",
            Email = "test@gmail.com",
            Password = "Test123",
            Login = "testuser"
        };

        var tokensPair = new TokensPair
        {
            Access = "access_token",
            Refresh = "refresh_token"
        };

        _mockService.Setup(service => service.RegisterAsync(
            newUser,
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(tokensPair);

        // Act
        var result = await _controller.RegisterAsync(newUser, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<TokensPair>(okResult.Value);
        Assert.Equal(tokensPair.Access, returnValue.Access);
        Assert.Equal(tokensPair.Refresh, returnValue.Refresh);

        _mockService.Verify(service => service.RegisterAsync(
            newUser,
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task LogoutAsync_ValidRefreshToken_ReturnsOkResult()
    {
        // Arrange
        var refreshToken = "refresh_token";
        var expectedResult = true;

        _mockService.Setup(service => service.LogOutAsync(
            refreshToken,
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResult);

        // Act
        var result = await _controller.LogoutAsync(refreshToken, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedResult, okResult.Value);

        _mockService.Verify(service => service.LogOutAsync(
            refreshToken,
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task RefreshAsync_ValidRefreshToken_ReturnsOkResultWithNewTokens()
    {
        // Arrange
        var refreshToken = "valid_refresh_token";
        var newTokensPair = new TokensPair
        {
            Access = "new_access_token",
            Refresh = "new_refresh_token"
        };

        _mockTokenService.Setup(service => service.RefreshTokensPairAsync(
            refreshToken,
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(newTokensPair);

        // Act
        var result = await _controller.RefreshAsync(refreshToken, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<TokensPair>(okResult.Value);
        Assert.Equal(newTokensPair.Access, returnValue.Access);
        Assert.Equal(newTokensPair.Refresh, returnValue.Refresh);

        _mockTokenService.Verify(service => service.RefreshTokensPairAsync(
            refreshToken,
            It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public void AttributeChecking()
    {
        // Arrange
        var controllerType = typeof(IdentitiesController);

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
        Assert.Equal("identities", routeAttribute?.Template);
    }
}