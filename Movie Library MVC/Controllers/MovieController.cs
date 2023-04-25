using Microsoft.AspNetCore.Mvc;

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
    }
}
