using System;

namespace MovieApp.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public string Actors { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Title))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Director))
            {
                return false;
            }
            if (Year < 1900 || Year > DateTime.Now.Year)
            {
                return false;
            }
            if (string.IsNullOrEmpty(Actors))
            {
                return false;
            }

            return true;
        }
    }
}
