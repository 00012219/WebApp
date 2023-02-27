using System;

namespace MovieApp.Model
{
    public class MovieDto
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public string[] Actors { get; set; }

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
            if (Actors == null || Actors.Length == 0)
            {
                return false;
            }

            return true;
        }
    }
}
