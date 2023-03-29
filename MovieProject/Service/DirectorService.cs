using Microsoft.EntityFrameworkCore;
using MovieProject.Data;
using MovieProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Service
{
    public class DirectorService : IDirectorService
    {
        private readonly MyDbContext _dbContext;

        public DirectorService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Director> GetAll()
        {
            return _dbContext.Directors.Include(d => d.MovieDirectors).ThenInclude(md => md.Movie).ToList();
        }

        public Director GetById(int id)
        {
            return _dbContext.Directors.Include(d => d.MovieDirectors).ThenInclude(md => md.Movie).FirstOrDefault(d => d.Id == id);
        }

        public void Create(Director director)
        {
            _dbContext.Directors.Add(director);
            _dbContext.SaveChanges();
        }

        public void Update(int id, Director director)
        {
            var existingDirector = _dbContext.Directors.Include(d => d.MovieDirectors).FirstOrDefault(d => d.Id == id);
            if (existingDirector != null)
            {
                existingDirector.FirstName = director.FirstName;
                existingDirector.LastName = director.LastName;
                existingDirector.Email = director.Email;
                existingDirector.BirthDate = director.BirthDate;
                existingDirector.MovieDirectors = director.MovieDirectors;
                _dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var director = _dbContext.Directors.Find(id);
            if (director != null)
            {
                _dbContext.Directors.Remove(director);
                _dbContext.SaveChanges();
            }
        }

        public List<Director> GetDirectorsWithMovies()
        {
            return _dbContext.Directors.Include(d => d.MovieDirectors)
                                      .ThenInclude(md => md.Movie)
                                      .ToList();
        }
    }
}
