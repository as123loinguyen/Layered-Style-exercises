using Xunit;
using Part8.Models;

public class UserTests
{
    [Fact]
    public void User_ShouldHaveName()
    {
        var user = new User { Name = "Emma" };

        Assert.NotEmpty(user.Name);
    }
}
