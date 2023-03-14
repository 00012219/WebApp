using MovieProject.Models;
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
    }

}
