using Microsoft.AspNetCore.Mvc;
using Test.Data;
using Test.Models;
using Test.Models.ViewModels;

namespace Test.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MoviesDbContext _moviesDbContext;
        public MoviesController(MoviesDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
        }
        [HttpGet]
        public IActionResult Movie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Movie(MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {

                Actors actor = new Actors()
                {
                    Name = movieViewModel.ActorName
                };

                Films film = new Films()
                {
                    Title = movieViewModel.Title,
                    Genre = movieViewModel.Genre,
                    Actor = actor
                };
                _moviesDbContext.Add(film);
                _moviesDbContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(movieViewModel);
        }
    }
}
