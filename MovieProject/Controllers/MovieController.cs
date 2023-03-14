using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieProject.Data;
using MovieProject.Models;
using MovieProject.Service;
using MovieProject.Payload;

namespace MovieProject.Controllers
{

    [Route("movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> GetAllMovies()
        {
            var movies = _movieService.GetAllMovies();
            var movieDtos = movies.Select(m => new MovieDto(m)).ToList();
            return Ok(movieDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<MovieDto> GetMovieById(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            var movieDto = new MovieDto(movie);
            return Ok(movieDto);
        }

        [HttpPost]
        public ActionResult<MovieDto> CreateMovie(CreateMovieDto createMovieDto)
        {
            var movie = _movieService.CreateMovie(createMovieDto);
            var movieDto = new MovieDto(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movieDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, UpdateMovieDto updateMovieDto)
        {
            if (!_movieService.MovieExists(id))
            {
                return NotFound();
            }
            _movieService.UpdateMovie(id, updateMovieDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            if (!_movieService.MovieExists(id))
            {
                return NotFound();
            }
            _movieService.DeleteMovie(id);
            return NoContent();
        }
    }



}
