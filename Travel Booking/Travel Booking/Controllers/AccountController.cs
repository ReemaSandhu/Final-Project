using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelBusinessLayer.Interface;
using TravelEntities.CustomEntities;
using TravelEntities.Entities;

namespace Travel_Booking.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        

        private readonly ITravelComponent _travelComponent;
        public AccountController(ITravelComponent travelComponent)
            {
            _travelComponent = travelComponent;
            }
        public IActionResult Login()
        {
            var user = HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme).Result;
            if (user.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Login", new Login());
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                bool isValid = _travelComponent.Login(login);
                if (isValid)
                {   
                    var Claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, login.UserName)
                    };
                    var claimsIdentity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrinciple, new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    });
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View();
        }
        public IActionResult Register()
            {   
                return View();
            }
            [HttpPost]
            public IActionResult Register(SignUp registration)
            {
                _travelComponent.Registration(registration);
                return RedirectToAction("Login");
            }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
    }

