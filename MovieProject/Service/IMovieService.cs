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
        public List<MovieDto> GetAll();
        public Movie GetById(int id);
        public Movie Create(Movie movie);
        public void Update(int id, Movie movie);
        public void Delete(int id);
        public bool MovieExists(int id);
        public double CalculateRating(Movie movie, string strategy);
        public void AddObserver(IMovieObserver observer);
        public void RemoveObserver(IMovieObserver observer);
        public Movie AssignDirectorToMovie(int movieId, int directorId);
    }
}
