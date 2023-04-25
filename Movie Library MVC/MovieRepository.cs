﻿using Dapper;
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
    }
}
