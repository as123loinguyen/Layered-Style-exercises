using Xunit;
using Part8.Repositories;
using Part8.Models;

public class UserRepositoryTests
{
    private readonly UserRepository _userRepository;

    public UserRepositoryTests()
    {
        _userRepository = new UserRepository();
    }

    [Fact]
    public void GetById_ShouldReturnNull_WhenUserDoesNotExist()
    {
        var result = _userRepository.GetById(999);

        Assert.Null(result);
    }
}
