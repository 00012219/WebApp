using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Models
{
    public class MovieDirector
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}
