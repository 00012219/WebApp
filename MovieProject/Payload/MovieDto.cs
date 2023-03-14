using MovieProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Payload
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RuntimeMinutes { get; set; }
        public string PosterUrl { get; set; }

        public MovieDto(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            Director = movie.Director;
            Genre = movie.Genre;
            Rating = movie.Rating;
            Description = movie.Description;
            ReleaseDate = movie.ReleaseDate;
            RuntimeMinutes = movie.RuntimeMinutes;
            PosterUrl = movie.PosterUrl;
        }
    }

}
