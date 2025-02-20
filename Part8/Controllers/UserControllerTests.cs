using Xunit;
using Moq;
using Part8.Controllers;
using Part8.Services;
using Part8.Models;
using Microsoft.AspNetCore.Mvc;

public class UserControllerTests
{
    private readonly Mock<IUserService> _userServiceMock;
    private readonly UserController _userController;

    public UserControllerTests()
    {
        _userServiceMock = new Mock<IUserService>();
        _userController = new UserController(_userServiceMock.Object);
    }

    [Fact]
    public void GetUser_ShouldReturnUser_WhenUserExists()
    {
        var user = new User { Id = 1, Name = "John Doe" };
        _userServiceMock.Setup(service => service.GetUserById(1)).Returns(user);

        var result = _userController.GetUser(1) as OkObjectResult;

        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(user, result.Value);
    }
}
