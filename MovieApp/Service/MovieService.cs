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

        //this method breaks both DRY as well as SRP principles
        public bool CreateMovie(string title, string director, int year, string[] actors)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title cannot be empty or null.");
            }
            if (string.IsNullOrEmpty(director))
            {
                throw new ArgumentException("Director cannot be empty or null.");
            }
            if (year < 1900 || year > DateTime.Now.Year)
            {
                throw new ArgumentOutOfRangeException("Year must be between 1900 and the current year.");
            }
            if (actors == null || actors.Length == 0)
            {
                throw new ArgumentException("At least one actor must be specified.");
            }

            var movie = new Movie
            {
                Title = title,
                Director = director,
                Year = year,
                Actors = string.Join(",", actors)
            };

            try
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
