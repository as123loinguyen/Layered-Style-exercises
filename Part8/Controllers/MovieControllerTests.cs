using Xunit;
using Moq;
using Part8.Controllers;
using Part8.Services;
using Part8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class MovieControllerTests
{
    private readonly Mock<IMovieService> _movieServiceMock;
    private readonly MovieController _movieController;

    public MovieControllerTests()
    {
        _movieServiceMock = new Mock<IMovieService>();
        _movieController = new MovieController(_movieServiceMock.Object);
    }

    [Fact]
    public void GetMovies_ShouldReturnListOfMovies()
    {
        var movies = new List<Movie> { new Movie { Title = "Inception" } };
        _movieServiceMock.Setup(service => service.GetAllMovies()).Returns(movies);

        var result = _movieController.GetMovies() as OkObjectResult;

        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(movies, result.Value);
    }
}
