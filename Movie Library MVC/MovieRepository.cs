using Dapper;
using Movie_Library_MVC.Models;
using System.Data;

namespace Movie_Library_MVC
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IDbConnection _conn;
        public MovieRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Movie> GetAllMovies()
        {
            return _conn.Query<Movie>("SELECT * FROM movie_library;");
        }
        public Movie GetMovie(int id)
        {
            return _conn.QuerySingle<Movie>("SELECT * FROM movie_library WHERE movieid = @id", new { id = id });
        }
        public void UpdateMovie(Movie movie)
        {
            _conn.Execute("UPDATE movie_library SET MovieName = @moviename," +
                " RatingScale = @ratingscale WHERE MovieID = @id",
                new { moviename = movie.MovieName, /*genrename = movie.GenreName, rateing = movie.Rating,*/
                    ratingscale = movie.RatingScale, /*seriesormovie = movie.SeriesOrMovie, */id = movie.MovieID });
        }
        //, GenreName = @genrename, Rating = @rating, SeriesOrMovie = @seriesormovie, 
        public void InsertMovie(Movie MovieToInsert)
        {
            _conn.Execute("INSERT INTO movie_library (MovieName, GenreName, Rating, RatingScale, SeriesOrMovie) VALUES (@moviename, @genrename, @rating, @ratingscale, @seriesormovie);",
                new { moviename = MovieToInsert.MovieName, genrename = MovieToInsert.GenreName, rating = MovieToInsert.Rating, ratingscale = MovieToInsert.RatingScale, seriesormovie = MovieToInsert.SeriesOrMovie });
        }
        public IEnumerable<Genre> GetGenre()
        {
            return _conn.Query<Genre>("SELECT * FROM genre;");
        }
        public Movie AssignGenre()
        {
            var genreList = GetGenre();
            var movie = new Movie();
            movie.Genre = genreList;
            return movie;
        }
        public void DeleteMovie(Movie movie)
        {
            _conn.Execute("DELETE FROM movie_library WHERE MovieID = @id;", new { id = movie.MovieID });
            
        }
    }
}
