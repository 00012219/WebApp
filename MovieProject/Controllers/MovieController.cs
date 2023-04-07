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
        public ActionResult<List<MovieDto>> GetAllMovies()
        {
            var movies = _movieService.GetAll();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            var movie = _movieService.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost]
        public ActionResult<Movie> CreateMovie(Movie createMovieDto)
        {
            var movie = _movieService.Create(createMovieDto);
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Movie movie)
        {
            if (!_movieService.MovieExists(id))
            {
                return NotFound();
            }
            _movieService.Update(id, movie);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            if (!_movieService.MovieExists(id))
            {
                return NotFound();
            }
            _movieService.Delete(id);
            return NoContent();
        }

        //assign the specific director to a movie
        [HttpPost("{movieId}/directors/{directorId}")]
        public IActionResult AssignDirectorToMovie(int movieId, int directorId)
        {
            try
            {
                var movie = _movieService.AssignDirectorToMovie(movieId, directorId);

                if (movie == null)
                {
                    return NotFound();
                }
                return CreatedAtAction(nameof(AssignDirectorToMovie), new { movieId, directorId }, movie);
            }
            catch (Exception ex)
            {
                return BadRequest("Director could not be assigned to the movie");
            }

            return null;

        }



        [HttpGet("{id}/rating/{strategy}")]
        public ActionResult<double> GetRating(int id, string strategy)
        {
            var movie = _movieService.GetById(id);

            if (movie == null)
            {
                return NotFound();
            }

            var rating = _movieService.CalculateRating(movie, strategy);

            return rating;
        }

    }



}
