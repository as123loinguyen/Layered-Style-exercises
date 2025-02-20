using Microsoft.EntityFrameworkCore;
using Multi_Layered_Architecture.part3.CoreLayer.Entities;

namespace Multi_Layered_Architecture.part3.DataAccessLayer
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.Include(m => m.Reviews).ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.Include(m => m.Reviews)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
