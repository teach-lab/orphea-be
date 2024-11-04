using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Moq;
using News.Controllers;
using News.Entities.Models;
using News.Entities.Models.ModelsRespones;
using News.Entities.Models.ModelsUpdate;
using News.Services.ServicesInterface;
using Xunit;

namespace News.Tests.Controllers;

public class UsersControllerTests
{
    private readonly Mock<IUserService> _serviceMock;
    private readonly Mock<ITokenService> _tokenServiceMock;
    private readonly UsersController _controller;

    public UsersControllerTests()
    {
        _serviceMock = new Mock<IUserService>();
        _tokenServiceMock = new Mock<ITokenService>();
        _controller = new UsersController(_serviceMock.Object, _tokenServiceMock.Object);
    }

    [Fact]
    public async Task GetByIdAsync_GetUser_ReturnsOkResult()
    {
        // Arrange
        var id = Guid.NewGuid();
        var newUser = new UserResponseModel
        {
            Id = id,
            FirstName = "nameTest",
            Email = "test@gmail.com",
            Login = "testuser"
        };

        _serviceMock.Setup(service => service.GetByIdAsync(
            id,
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(newUser);

        // Act
        var result = await _controller.GetByIdAsync(id, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<UserResponseModel>(okResult.Value);
        Assert.Equal(newUser.FirstName, returnValue.FirstName);
        Assert.Equal(newUser.Email, returnValue.Email);
        Assert.Equal(newUser.Login, returnValue.Login);

        _serviceMock.Verify(service => service.GetByIdAsync(id, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_UpdateUser_ReturnsOkResult()
    {
        // Arrange
        var id = Guid.NewGuid();
        var newUser = new UserModel
        {
            FirstName = "nameTest",
            Email = "test@gmail.com",
            Login = "testuser"
        };

        var updateModel = new UserResponseModel
        {
            Id = id,
            FirstName = "newNameTEST",
            Email = "test@gmail.com",
            Login = "testuser"
        };

        var patchDocument = new JsonPatchDocument<UserUpdateModel>();
        patchDocument.Replace(user => user.FirstName, "newNameTEST");

        _serviceMock.Setup(service => service.UpdateAsync(
            patchDocument,
            id.ToString(),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(updateModel);

        // Act
        var result = await _controller.UpdateAsync(
            id.ToString(),
            patchDocument,
            CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<UserResponseModel>(okResult.Value);
        Assert.Equal(updateModel.FirstName, returnValue.FirstName);
        Assert.Equal(newUser.Email, returnValue.Email);
        Assert.Equal(newUser.Login, returnValue.Login);

        _serviceMock.Verify(service => service.UpdateAsync(patchDocument, id.ToString(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_DeleteUser_ReturnsOkResult()
    {
        // Arrange
        var id = Guid.NewGuid();

        _serviceMock.Setup(service => service.DeleteAsync(
            id,
            It.IsAny<CancellationToken>()));

        // Act
        var result = await _controller.DeleteAsync(id, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkResult>(result);

        _serviceMock.Verify(service => service.DeleteAsync(id, It.IsAny<CancellationToken>()), Times.Once);
    }
}