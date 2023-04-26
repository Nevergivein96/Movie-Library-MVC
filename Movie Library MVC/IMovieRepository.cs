using Movie_Library_MVC.Models;

namespace Movie_Library_MVC
{
    public interface IMovieRepository
    {
        public IEnumerable<Movie> GetAllMovies();
        public Movie GetMovie(int id);
    }
}
