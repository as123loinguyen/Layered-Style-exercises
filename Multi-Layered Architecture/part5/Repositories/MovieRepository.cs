using Microsoft.EntityFrameworkCore;
using Multi_Layered_Architecture.part5.Models;
using Multi_Layered_Architecture.part5.Data;

namespace Multi_Layered_Architecture.part5.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie?> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return false;

            _context.Movies.Remove(movie);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
