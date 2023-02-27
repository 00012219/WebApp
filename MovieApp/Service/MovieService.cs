using MovieApp.Model;
using System;
using System.Data.Entity;

namespace MovieApp.Service
{

    public class MovieService : IMovieService
    {
        private readonly DbContext _context;

        public MovieService(DbContext context)
        {
            _context = context;
        }

        public bool CreateMovie(MovieDto movieDto)
        {
            var movie = MapDtoToMovie(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return true;
        }

        private Movie MapDtoToMovie(MovieDto movieDto)
        {
            ValidateMovieDto(movieDto);

            var movie = new Movie
            {
                Title = movieDto.Title,
                Director = movieDto.Director,
                Year = movieDto.Year,
                Actors = string.Join(",", movieDto.Actors)
            };

            return movie;
        }

        private void ValidateMovieDto(MovieDto movieDto)
        {
            if (string.IsNullOrEmpty(movieDto.Title))
            {
                throw new ArgumentException("Title cannot be empty or null.");
            }
            if (string.IsNullOrEmpty(movieDto.Director))
            {
                throw new ArgumentException("Director cannot be empty or null.");
            }
            if (movieDto.Year < 1900 || movieDto.Year > DateTime.Now.Year)
            {
                throw new ArgumentOutOfRangeException("Year must be between 1900 and the current year.");
            }
            if (movieDto.Actors == null || movieDto.Actors.Length == 0)
            {
                throw new ArgumentException("At least one actor must be specified.");
            }
        }
    }
}
