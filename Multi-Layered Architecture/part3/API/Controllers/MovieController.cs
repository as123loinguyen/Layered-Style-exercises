﻿using Microsoft.AspNetCore.Mvc;
using Multi_Layered_Architecture.part3.CoreLayer.Entities;
using Multi_Layered_Architecture.part3.ServiceLayer;

namespace Multi_Layered_Architecture.part3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }
    }
}
