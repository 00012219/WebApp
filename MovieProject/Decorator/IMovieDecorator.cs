using MovieProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Decorator
{
    public interface IMovieDecorator
    {
        void Decorate(Movie movie);
    }
}
