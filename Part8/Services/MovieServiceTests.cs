using Xunit;
using Moq;
using Part8.Services;
using Part8.Repositories;
using Part8.Models;

public class MovieServiceTests
{
    private readonly Mock<IMovieRepository> _movieRepoMock;
    private readonly MovieService _movieService;

    public MovieServiceTests()
    {
        _movieRepoMock = new Mock<IMovieRepository>();
        _movieService = new MovieService(_movieRepoMock.Object);
    }

    [Fact]
    public void AddMovie_ShouldReturnTrue_WhenMovieIsValid()
    {
        var movie = new Movie { Title = "Inception", Genre = "Sci-Fi" };
        _movieRepoMock.Setup(repo => repo.Add(movie)).Returns(true);

        var result = _movieService.AddMovie(movie);

        Assert.True(result);
    }
}
