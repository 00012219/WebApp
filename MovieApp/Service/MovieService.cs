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

       

       

       
    }
}
