using MovieProject.Models;
using MovieProject.Observer;
using MovieProject.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Service
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        Movie CreateMovie(CreateMovieDto createMovieDto);
        void UpdateMovie(int id, UpdateMovieDto updateMovieDto);
        void DeleteMovie(int id);
        bool MovieExists(int id);

        public double CalculateRating(Movie movie, string strategy);

        void AddObserver(IMovieObserver observer);
        void RemoveObserver(IMovieObserver observer);
    }

}
