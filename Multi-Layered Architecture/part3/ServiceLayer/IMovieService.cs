using Multi_Layered_Architecture.part3.CoreLayer.Entities;

namespace Multi_Layered_Architecture.part3.ServiceLayer
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<IEnumerable<Movie>> GetTopRatedMoviesWithSpAsync(int topCount); // Thêm phương thức này
    }
}
