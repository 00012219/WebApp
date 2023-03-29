using MovieProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Service
{
    public interface IDirectorService
    {
        public List<Director> GetAll();
        public Director GetById(int id);
        public void Create(Director director);
        public void Update(int id, Director director);
        public void Delete(int id);
    }
}
