using ASPCoreFirstApp.Models;
using ASPCoreFirstApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MovieController : Controller
    {
        // GET: /Movie
        public IActionResult Index()
        {
            List<Movie> movies = new List<Movie>()
            {
                new Movie { Id=1, Name="Movie 1" },
                new Movie { Id=2, Name="Movie 2" },
                new Movie { Id=3, Name="Movie 3" }
            };

            return View(movies);
        }

        // GET: /Movie/Edit/1
        public IActionResult Edit(int id)
        {
            return Content("Test Id " + id);
        }

        // ✅ Convention Based Routing
        // GET: /Movie/ByRelease/2020/3
        public IActionResult ByRelease(int year, int month)
        {
            return Content($"Movies released in {month}/{year}");
        }

        // ✅ Attribute Routing
        [Route("Movie/released/{year:int}/{month:int}")]
        public IActionResult Released(int year, int month)
        {
            return Content($"(Attribute Routing) Movies released in {month}/{year}");
        }

        // GET: /Movie/Details/1
        public IActionResult Details(int id)
        {
            var movie = new Movie { Id = id, Name = "Movie " + id };
            return View(movie);
        }

        // Pass Customer + Movies using ViewModel
        public IActionResult CustomerMovies()
        {
            var customer = new Customer
            {
                Id = 1,
                Name = "Ahmed"
            };

            var movies = new List<Movie>
            {
                new Movie { Id=1, Name="Movie 1" },
                new Movie { Id=2, Name="Movie 2" }
            };

            var viewModel = new MovieCustomerViewModel
            {
                Customer = customer,
                Movies = movies
            };

            return View(viewModel);
        }
    }
}