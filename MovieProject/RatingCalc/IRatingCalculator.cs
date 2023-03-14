using MovieProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.RatingCalc
{
    public interface IRatingCalculator
    {
        double CalculateRating(Movie movie);
    }

}
