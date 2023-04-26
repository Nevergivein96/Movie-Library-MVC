using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

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
    }
}
