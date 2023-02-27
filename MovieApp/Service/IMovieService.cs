using MovieApp.Model;

namespace MovieApp.Service
{
    public interface IMovieService
    {
        bool CreateMovie(MovieDto movieDto);
    }
}
