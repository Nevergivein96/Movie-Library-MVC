using Movie_Library_MVC.Models;

namespace Movie_Library_MVC
{
    public interface IMovieRepository
    {
        public IEnumerable<Movie> GetAllMovies();
        public Movie GetMovie(int id);
        public void UpdateMovie(Movie movie);
        public void InsertMovie(Movie MovieToInsert);
        public IEnumerable<Genre> GetGenre();
        public Movie AssignGenre();
        public void DeleteMovie(Movie movie);
    }
}
