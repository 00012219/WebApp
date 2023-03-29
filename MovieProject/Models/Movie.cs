using MovieProject.RatingCalc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Genre { get; set; }

        [Range(0, 10)]
        public double Rating { get; set; }

        public DateTime ReleaseDate { get; set; }

        public List<MovieDirector> MovieDirectors { get; set; }


        // Add a field to hold the rating calculator
        private IRatingCalculator _ratingCalculator;

        // Add a property to set the rating calculator
        public void SetRatingCalculator(IRatingCalculator ratingCalculator)
        {
            _ratingCalculator = ratingCalculator;
        }

        // Calculate the rating using the current rating calculator
        public double CalculateRating()
        {
            return _ratingCalculator.CalculateRating(this);
        }
    }
}
