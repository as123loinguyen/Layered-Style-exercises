using Xunit;
using Moq;
using Part8.Services;
using Part8.Repositories;
using Part8.Models;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _userRepoMock;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _userRepoMock = new Mock<IUserRepository>();
        _userService = new UserService(_userRepoMock.Object);
    }

    [Fact]
    public void GetUserById_ShouldReturnUser_WhenUserExists()
    {
        var user = new User { Id = 1, Name = "Alice" };
        _userRepoMock.Setup(repo => repo.GetById(1)).Returns(user);

        var result = _userService.GetUserById(1);

        Assert.NotNull(result);
        Assert.Equal(user.Name, result.Name);
    }
}
