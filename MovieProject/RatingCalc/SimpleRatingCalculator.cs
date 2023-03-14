using MovieProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.RatingCalc
{
    public class SimpleRatingCalculator : IRatingCalculator
    {
        public double CalculateRating(Movie movie)
        {
            // Calculate the rating using a simple algorithm
            double rating = (movie.Rating * 2) / 10.0;
            return rating;
        }
    }

}
