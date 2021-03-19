using System;
using TheOldHat.Common.Interfaces;
using TheOldHat.Models;
using TheOldHat.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TheOldHat.Controllers
{
    public class AccountController : Controller
    {
        private readonly INativeAuthenticationService _authenticationService;
        private readonly IApplicationUserRepository _userRepository;

        public AccountController(INativeAuthenticationService authenticationService, IApplicationUserRepository userRepository)
        {
            _authenticationService = authenticationService;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var applicationUsers = _userRepository.GetAll();
            var model = new ApplicationUserViewModel(applicationUsers);

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var user = _userRepository.GetOne(id);

            var model = new ApplicationUserUpdateViewModel(user);

            if(user == null)
            {
                new ArgumentException("id");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ApplicationUserUpdateViewModel model)
        {
            var user = _userRepository.GetOne(model.Id);

            if(user == null)
            {
                new ArgumentException("id");
            }

            user.ChangeFirstName(model.FirstName);
            user.ChangeLastName(model.LastName);
            user.ChangeEmail(model.Email);
            user.ChangePassword(model.Password);
            user.ChangeLanguage(model.Language);

            _userRepository.Update(user);

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Secret()
        {
            var model = new SecretViewModel
            {
                Users = _userRepository.GetAll()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _userRepository.Add(model.ToApplicationUser());

            return LocalRedirect("/");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            var model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _authenticationService.SignIn(this.HttpContext, model.Email, model.Password);

            if(result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                model.Error = result.Error;
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _authenticationService.SignOut(this.HttpContext);
            return Redirect("/");
        }

    }
}
