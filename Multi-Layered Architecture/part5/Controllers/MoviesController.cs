using Microsoft.AspNetCore.Mvc;
using Multi_Layered_Architecture.part5.Models;
using Multi_Layered_Architecture.part5.Services;

namespace Multi_Layered_Architecture.part5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            return Ok(await _movieService.GetAllMoviesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            return movie == null ? NotFound() : Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] Movie movie)
        {
            return Ok(await _movieService.AddMovieAsync(movie));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] Movie movie)
        {
            if (id != movie.Id) return BadRequest("ID mismatch");
            return await _movieService.UpdateMovieAsync(movie) ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            return await _movieService.DeleteMovieAsync(id) ? Ok() : NotFound();
        }
    }
}
