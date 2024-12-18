using JokesApp.Data;
using JokesApp.Interfaces;
using JokesApp.Models;
using JokesApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JokesApp.Controllers
{
    public class RatingController : Controller
    {
        private readonly IRatingService _ratingService;
        private readonly IHttpContextAccessor _contextAccessor;

        public RatingController(IRatingService ratingService, IHttpContextAccessor contextAccessor)
        {
            _ratingService = ratingService;
            _contextAccessor = contextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> Create(JokeDetailsViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var curUserId = _contextAccessor.HttpContext.User.GetUserId();

            var existingRating = await _ratingService.GetRatingByUserAndJokeAsync(curUserId, model.JokeId);
            if (existingRating != null)
            {
                Console.WriteLine("User has already rated this joke.");
                return RedirectToAction("Index", "Joke");
            }
            var rating = new Rating
            {
                JokeId = model.JokeId,
                UserId = curUserId,
                RatingValue = model.RatingValue.HasValue ? model.RatingValue.Value : 0,
                CreatedAt = DateTime.Now
            };

            await _ratingService.AddAsync(rating);
            Console.WriteLine("Rating added successfully.");
            

            return RedirectToAction("Index", "Joke");
        }
        
    }
}
