using MovieApp.Model;

namespace MovieApp.Service
{
    public interface IMovieService
    {
        bool CreateMovie(string title, string director, int year, string[] actors);
    }
}
