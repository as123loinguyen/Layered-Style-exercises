using Multi_Layered_Architecture.part3.CoreLayer.Entities;

namespace Multi_Layered_Architecture.part3.DataAccessLayer
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
    }
}
