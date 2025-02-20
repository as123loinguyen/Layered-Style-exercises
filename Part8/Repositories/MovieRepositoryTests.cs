using Xunit;
using Part8.Repositories;
using Part8.Models;
using System.Collections.Generic;

public class MovieRepositoryTests
{
    private readonly MovieRepository _movieRepository;

    public MovieRepositoryTests()
    {
        _movieRepository = new MovieRepository();
    }

    [Fact]
    public void Add_ShouldReturnTrue_WhenMovieIsValid()
    {
        var movie = new Movie { Title = "Interstellar", Genre = "Sci-Fi" };

        var result = _movieRepository.Add(movie);

        Assert.True(result);
    }
}
