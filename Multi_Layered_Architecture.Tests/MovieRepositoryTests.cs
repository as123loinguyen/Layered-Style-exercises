using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Multi_Layered_Architecture.part3.CoreLayer.Entities;
using Multi_Layered_Architecture.part3.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace Multi_Layered_Architecture.Tests
{
    public class MovieRepositoryTests
    {
        private readonly DbContextOptions<AppDbContext> _options;

        public MovieRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
        }

        [Fact]
        public async Task GetAllMoviesAsync_ReturnsListOfMovies()
        {
            using (var context = new AppDbContext(_options))
            {
                context.Movies.Add(new Movie { Id = 1, Title = "Movie 1" });
                context.Movies.Add(new Movie { Id = 2, Title = "Movie 2" });
                await context.SaveChangesAsync();
            }

            using (var context = new AppDbContext(_options))
            {
                var repository = new MovieRepository(context);
                var movies = await repository.GetAllMoviesAsync();

                Assert.NotNull(movies);
                Assert.Equal(2, movies.Count());
            }
        }
    }
}
