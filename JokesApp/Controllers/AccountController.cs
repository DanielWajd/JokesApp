using CarRentwithDB.Data;
using JokesApp.Data;
using JokesApp.Data.Enum;
using JokesApp.Interfaces;
using JokesApp.Models;
using JokesApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JokesApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;

        public AccountController(IUserService userService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _contextAccessor = contextAccessor;
        }
        //Get
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }
        //Post
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var user = await _userManager.FindByNameAsync(loginViewModel.EmailAddress);

            if (user != null)
            {
                
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (passwordCheck)
                {
                    
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Joke");
                    }
                }
                
                TempData["Error"] = "Złe hasło";
                return View(loginViewModel);
            }
            //When User not found
            TempData["Error"] = "Nie ma takiego użytkownika";
            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var user = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerViewModel);
            }

            var newUser = new AppUser()
            {
                Name = registerViewModel.Name,
                Surname = registerViewModel.Surname,
                Phone = registerViewModel.Phone,
                Email = registerViewModel.EmailAddress,
                UserName = registerViewModel.EmailAddress,
                UserType = registerViewModel.UserType
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return RedirectToAction("Index", "Joke");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Details()
        {
            var curUser = _contextAccessor.HttpContext.User.GetUserId();
            var user = await _userService.GetUserById(curUser);
            if (curUser == null)
            {
                return NotFound("User not found");
            }
            var userDetailsViewModel = new UserDetailsViewModel
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Phone = user.Phone,
                UserType = user.UserType,
                Ratings = user.Ratings ?? new List<Rating>(),
                UserJokes = user.UserJokes ?? new List<UserJoke>()
            };
            return View(userDetailsViewModel);
        }
    }
}
