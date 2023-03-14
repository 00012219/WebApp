using MovieProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Decorator
{
    public class RatingDecorator : IMovieDecorator
    {
        public void Decorate(Movie movie)
        {
            // Add additional behavior to the movie object
            movie.Rating *= 2;
        }
    }
}
