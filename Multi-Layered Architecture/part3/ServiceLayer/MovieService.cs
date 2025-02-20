using Multi_Layered_Architecture.part3.CoreLayer.Entities;
using Multi_Layered_Architecture.part3.DataAccessLayer;

namespace Multi_Layered_Architecture.part3.ServiceLayer
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // CRUD Methods
        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllMoviesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _movieRepository.GetMovieByIdAsync(id);
        }

        public async Task AddMovieAsync(Movie movie)
        {
            var existingMovies = await _movieRepository.GetAllMoviesAsync();
            if (existingMovies.Any(m => m.Title == movie.Title))
            {
                throw new ArgumentException("A movie with the same title already exists.");
            }
            await _movieRepository.AddMovieAsync(movie);
        }

        // Stored Procedure Method
        public async Task<IEnumerable<Movie>> GetTopRatedMoviesWithSpAsync(int topCount)
        {
            try
            {
                return await _movieRepository.GetTopRatedMoviesWithSpAsync(topCount);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving top-rated movies.", ex);
            }
        }
    }
}
