using JokesApp.Interfaces;
using JokesApp.Models;
using JokesApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JokesApp.Controllers
{
    public class JokeController : Controller
    {
        private readonly IJokeService _jokeService;

        public JokeController(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Joke> jokes = await _jokeService.GetAll();
            return View(jokes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(JokeViewModel jokeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(jokeViewModel);
            }
            var joke = new Joke
            {
                Category = jokeViewModel.Category,
                JokeContent = jokeViewModel.JokeContent
            };
            _jokeService.AddAsync(joke);
            return RedirectToAction("Index");
        }
    }
}
