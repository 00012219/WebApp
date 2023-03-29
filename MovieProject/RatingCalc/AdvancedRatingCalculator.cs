using MovieProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.RatingCalc
{
    public class AdvancedRatingCalculator : IRatingCalculator
    {
        public double CalculateRating(Movie movie)
        {
            // Calculate the rating using a more advanced algorithm
            double rating = (movie.Rating) / 1000.0;
            return rating;
        }
    }
}
