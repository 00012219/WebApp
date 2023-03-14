using MovieProject.Data;
using MovieProject.Models;
using MovieProject.Payload;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieProject.Service
{

    public class MovieService : IMovieService
    {
        private readonly MyDbContext _dbContext;

        public MovieService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _dbContext.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _dbContext.Movies.Find(id);
        }

        public Movie CreateMovie(CreateMovieDto createMovieDto)
        {
            var movie = new Movie
            {
                Title = createMovieDto.Title,
                ReleaseDate = createMovieDto.ReleaseDate,
                Description = createMovieDto.Description,
                Director = createMovieDto.Director,
                Genre = createMovieDto.Genre,
                PosterUrl = createMovieDto.PosterUrl,
                Rating = createMovieDto.Rating,
                RuntimeMinutes = createMovieDto.RuntimeMinutes
            };
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            return movie;
        }

        public void UpdateMovie(int id, UpdateMovieDto updateMovieDto)
        {
            var movie = _dbContext.Movies.Find(id);
            movie.Title = updateMovieDto.Title;
            movie.ReleaseDate = updateMovieDto.ReleaseDate;
            movie.PosterUrl = updateMovieDto.PosterUrl;
            movie.RuntimeMinutes = updateMovieDto.RuntimeMinutes;
            movie.Rating = updateMovieDto.Rating;
            movie.Genre = updateMovieDto.Genre;
            movie.Director = updateMovieDto.Director;
            movie.Description = updateMovieDto.Description;

            _dbContext.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = _dbContext.Movies.Find(id);
            if (movie != null)
            {
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
            }
        }

        public bool MovieExists(int id)
        {
            return _dbContext.Movies.Any(m => m.Id == id);
        }
    }
}
