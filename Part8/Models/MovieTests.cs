using Xunit;
using Part8.Models;

public class MovieTests
{
    [Fact]
    public void Movie_ShouldHaveValidTitle()
    {
        var movie = new Movie { Title = "Dune", Genre = "Sci-Fi" };

        Assert.NotEmpty(movie.Title);
    }
}
