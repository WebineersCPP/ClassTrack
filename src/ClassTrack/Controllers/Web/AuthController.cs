using ClassTrack.Models;
using ClassTrack.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Controllers.Web
{
    public class AuthController : Controller
    {
        private SignInManager<ClassTrackUser> _signInManager;
        private UserManager<ClassTrackUser> _userManager;

        public AuthController(SignInManager<ClassTrackUser> signInManager, UserManager<ClassTrackUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Home", "App");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Home", "App");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password incorrect");
                }
            }
            return View();
        }

        public IActionResult Register()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Home", "App");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = new ClassTrackUser()
                {
                    UserName = vm.Username.Trim(),
                    Email = vm.Email,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                };

                var result = await _userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    // Authenticate user and redirect to Home page
                    await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, false);
                    return RedirectToAction("Home", "App");
                }
                else
                {
                    List<IdentityError> errors = result.Errors.ToList();
                    foreach (IdentityError err in errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Some data fields are invalid.");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "App");
        }
    }
}
