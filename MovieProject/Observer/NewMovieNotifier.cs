using MovieProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Observer
{
    public class NewMovieNotifier : IMovieObserver
    {
        public void Update(Movie movie)
        {
            Console.WriteLine($"New movie added: {movie.Title}");
            // or send an email, update a cache, etc.
        }
    }

}
