using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Movie_Library_MVC.Models;

namespace Movie_Library_MVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository repo;

        public MovieController(IMovieRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var movies = repo.GetAllMovies();
            return View(movies);
        }
        public IActionResult ViewMovie(int id)
        {
            var movie = repo.GetMovie(id);
            return View(movie);
        }
        public IActionResult UpdateMovie(int id)
        {
            Movie mov = repo.GetMovie(id);
            if (mov == null)
            {
                return View("MovieNotFound");
            }
            return View(mov);
        }
        public IActionResult UpdateMovieToDatabase(Movie movie)
        {
            repo.UpdateMovie(movie);

            return RedirectToAction("ViewMovie", new { id = movie.MovieID });
        }
        public IActionResult InsertMovie()
        {
            var movie = repo.AssignGenre();
            return View(movie);
        }
        public IActionResult InsertMovieToDatabase(Movie movieToInsert)
        {
            repo.InsertMovie(movieToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteMovie(Movie movie)
        {
            repo.DeleteMovie(movie);
            return RedirectToAction("Index");
        }



    }
}
