using Microsoft.EntityFrameworkCore;
using MovieProject.Data;
using MovieProject.Exceptions;
using MovieProject.Models;
using MovieProject.Observer;
using MovieProject.Payload;
using MovieProject.RatingCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieProject.Service
{

    public class MovieService : IMovieService
    {
        private readonly MyDbContext _dbContext;
        private readonly IRatingCalculator _ratingCalculator;
        private readonly List<IMovieObserver> _observers = new List<IMovieObserver>();


        public MovieService(MyDbContext dbContext, IRatingCalculator ratingCalculator)
        {
            _dbContext = dbContext;
            _ratingCalculator = ratingCalculator;
        }

        public List<MovieDto> GetAll()
        {
            var movies = _dbContext.Movies.Include(m => m.MovieDirectors).ThenInclude(md => md.Director).ToList();

            var movieDtos = new List<MovieDto>();
            foreach (var movie in movies)
            {
                var directors = movie.MovieDirectors.Select(md => md.Director).ToList();

                var movieDto = new MovieDto
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Genre = movie.Genre,
                    Rating = movie.Rating,
                    ReleaseDate = movie.ReleaseDate,
                    Directors = directors
                };

                movieDtos.Add(movieDto);
            }

            return movieDtos;
        }

        public Movie GetById(int id)
        {
            return _dbContext.Movies.Include(m => m.MovieDirectors).ThenInclude(md => md.Director).FirstOrDefault(m => m.Id == id);
        }

        public Movie Create(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            foreach (var observer in _observers)
            {
                observer.Update(movie);
            }
            return movie;
                
        }

        public void Update(int id, Movie movie)
        {
            var existingMovie = _dbContext.Movies.Include(m => m.MovieDirectors).FirstOrDefault(m => m.Id == id);
            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.Genre = movie.Genre;
                existingMovie.Rating = movie.Rating;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.MovieDirectors = movie.MovieDirectors;
                _dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var movie = _dbContext.Movies.Find(id);
            if (movie != null)
            {
                // Remove MovieDirector records that reference the movie
                var movieDirectors = _dbContext.MovieDirectors.Where(md => md.MovieId == id);
                _dbContext.MovieDirectors.RemoveRange(movieDirectors);



                // Remove Movie record
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
            }
        }



        public Movie AssignDirectorToMovie(int movieId, int directorId)
        {
            var movie = _dbContext.Movies.Include(m => m.MovieDirectors).FirstOrDefault(m => m.Id == movieId);
            var director = _dbContext.Directors.FirstOrDefault(d => d.Id == directorId);

            if (movie == null || director == null)
            {
                return null;
            }

            var movieDirector = new MovieDirector
            {
                Movie = movie,
                Director = director
            };

            if (movie.MovieDirectors == null)
            {
                movie.MovieDirectors = new List<MovieDirector>();
            }

            try
            {
                movie.MovieDirectors.Add(movieDirector);
                _dbContext.SaveChanges();
            }catch(Exception ex)
            {
                throw new HttpStatusException(HttpStatusCode.InternalServerError, "An error occurred while assigning the director to the movie.", ex);
            }



            return movie;
        }

        public bool MovieExists(int id)
        {
            return _dbContext.Movies.Any(m => m.Id == id);
        }


        public double CalculateRating(Movie movie, string strategy)
        {
            IRatingCalculator ratingCalculator;

            switch (strategy)
            {
                case "simple":
                    ratingCalculator = new SimpleRatingCalculator();
                    break;
                case "advanced":
                    ratingCalculator = new AdvancedRatingCalculator();
                    break;
                default:
                    throw new ArgumentException("Invalid strategy parameter");
            }

            var rating = ratingCalculator.CalculateRating(movie);

            return rating;
        }

        public void AddObserver(IMovieObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IMovieObserver observer)
        {
            _observers.Remove(observer);
        }
    }
}
