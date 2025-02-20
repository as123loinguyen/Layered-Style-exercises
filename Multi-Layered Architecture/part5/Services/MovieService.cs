using Multi_Layered_Architecture.part5.Models;
using Multi_Layered_Architecture.part5.Repositories;

namespace Multi_Layered_Architecture.part5.Services
{
    public class MovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync() => await _movieRepository.GetAllMoviesAsync();
        public async Task<Movie?> GetMovieByIdAsync(int id) => await _movieRepository.GetMovieByIdAsync(id);
        public async Task<Movie> AddMovieAsync(Movie movie) => await _movieRepository.AddMovieAsync(movie);
        public async Task<bool> UpdateMovieAsync(Movie movie) => await _movieRepository.UpdateMovieAsync(movie);
        public async Task<bool> DeleteMovieAsync(int id) => await _movieRepository.DeleteMovieAsync(id);
    }
}
