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
                Actors actor = _moviesDbContext.Actors.Where(name => name.Name == movieViewModel.ActorName).FirstOrDefault();
                if (actor == null)
                {
                    actor = new Actors()
                    {
                        Name = movieViewModel.ActorName
                    };
                }
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

        public IActionResult MovieDetails()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieDetails(string Title)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("SeeDetails", "Movies");

            }
            return View();
        }
        
        public IActionResult SeeDetails(string movieTitle)
        {
            if (ModelState.IsValid)
            {
                MovieViewModel movieViewModel = new MovieViewModel();
                Films film = _moviesDbContext.Films.Where(film => film.Title == movieTitle).FirstOrDefault();
                if (film == null)
                {
                    TempData["MovieNotFound"] = "Movie Not Found";
                    return RedirectToAction("MovieDetails", "Movies");
                }
                Actors actor = _moviesDbContext.Actors.Find(film.ActorId);

                movieViewModel.Title = movieTitle;
                movieViewModel.Genre = film.Genre;
                movieViewModel.ActorName = actor.Name;

                return View(movieViewModel);
            }
            return RedirectToAction("MovieDetails", "Movies");
        }
    }
}
