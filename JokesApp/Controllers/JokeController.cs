using JokesApp.Data;
using JokesApp.Interfaces;
using JokesApp.Models;
using JokesApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JokesApp.Controllers
{
    public class JokeController : Controller
    {
        private readonly IJokeService _jokeService;
        private readonly IRatingService _ratingService;
        private readonly IUserJokeService _userJokeService;
        private readonly IHttpContextAccessor _contextAccessor;

        public JokeController(IJokeService jokeService, IUserJokeService userJokeService, IRatingService ratingService, IHttpContextAccessor httpContextAccessor)
        {
            _jokeService = jokeService;
            _ratingService = ratingService;
            _userJokeService = userJokeService;
            _contextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            var jokes = await _jokeService.GetAll();

            var jokeViewModels = jokes.Select(joke => new JokeIndexViewModel
            {
                Id = joke.Id,
                Category = joke.Category,
                JokeContent = joke.JokeContent,
                CreatedAt = joke.CreatedAt,
                AverageRating = joke.Ratings.Any() ? joke.Ratings.Average(r => r.RatingValue) : 0,
                RatingsCount = joke.Ratings.Count()
            }).ToList();

            return View(jokeViewModels);
        }
        public async Task<IActionResult> Details(int id)
        {
            var joke = await _jokeService.GetByIdAsync(id);
            if (joke == null)
            {
                return NotFound();
            }

            var ratings = await _ratingService.GetRatingsByJokeIdAsync(id);
            var averageRating = ratings.Any() ? ratings.Average(r => r.RatingValue) : 0;
            var ratingsCount = ratings.Count();

            var viewModel = new JokeDetailsViewModel
            {
                JokeId = joke.Id,
                JokeContent = joke.JokeContent,
                Category = joke.Category,
                CreatedAt = joke.CreatedAt,
                AverageRating = averageRating,
                RatingsCount = ratingsCount,
                Ratings = ratings
            };

            return View(viewModel);
        }
        public async Task<IActionResult> Create()
        {
            var curUserId = _contextAccessor.HttpContext.User.GetUserId();
            if (string.IsNullOrEmpty(curUserId))
            {
                return Unauthorized(); 
            }

            
            var createJokeViewModel = new CreateJokeViewModel { AppUserId = curUserId };
            return View(createJokeViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateJokeViewModel createjokeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createjokeViewModel);
            }

            var curUserId = _contextAccessor.HttpContext.User.GetUserId();
            if (string.IsNullOrEmpty(curUserId))
            {
                return Unauthorized();
            }

            var joke = new Joke
            {
                Category = createjokeViewModel.Category,
                JokeContent = createjokeViewModel.JokeContent,
                CreatedAt = DateTime.Now
            };

            await _jokeService.AddAsync(joke);
            await _jokeService.SaveAsync();
            Console.WriteLine($"Joke ID: {joke.Id}");
            var userJoke = new UserJoke
            {
                UserId = curUserId,
                JokeId = joke.Id 
            };

            await _userJokeService.AddAsync(userJoke);
            await _userJokeService.SaveAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var joke = await _jokeService.GetByIdAsync(id);
            if (joke == null)
            {
                return View("Error");
            }
            var createJokeViewModel = new EditJokeViewModel
            {
                Category = joke.Category,
                JokeContent = joke.JokeContent
            };
            return View(createJokeViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditJokeViewModel editJokeViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Cannot edit");
                return View("Edit", editJokeViewModel);
            }
            var joke = await _jokeService.GetByIdAsync(id);
            if (joke == null)
            {
                return View("Error");
            }
            joke.JokeContent = editJokeViewModel.JokeContent;
            joke.Category = editJokeViewModel.Category;
            _jokeService.UpdateAsync(joke);
            return RedirectToAction("Index");
        }
    }
}
