using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer;
using BusinessLayer.Dependency.IDependency;
using BusinessModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Core_Assignment.Controllers.Account
{
    public class AccountController : Controller
    {
        //private readonly ProductDbContext _context;
        private readonly INotyfService _notyf;

        private readonly IAccountBL _iaccountBL;
        public AccountController(INotyfService notyf,IAccountBL _iaccountBL)
        {
            _notyf = notyf;

            
            this._iaccountBL = _iaccountBL;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storedCookies = Request.Cookies.Keys;
            foreach(var cookies in storedCookies)
            {
                Response.Cookies.Delete(cookies);
            }
            return RedirectToAction("Login","Account");
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
           if(ModelState.IsValid)
            {
               
                var data = _iaccountBL.Login(model);

                if (data != null)
                {
                    bool isValid = (data.Email == model.Email && data.Password == model.Password);
                    if (isValid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.Email) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Email", model.Email);
                        _notyf.Custom("Successfully Logged In!", 3, "lightgreen", "fa fa-home");
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        TempData["errorPassword"] = "Invalid Password!";
                        return View(model);
                    }
                }
                else
                {
                    TempData["errorEmail"] = "Email not found";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }

        }
       
       
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel model)
        {

            if (ModelState.IsValid)
            {
               

                _iaccountBL.SignUp(model);
                _notyf.Custom("Successfully Registered!", 3, "lightgreen");
                return RedirectToAction("Login");
            }
            else
            {

                return View(model);

            }

        }
    }
}
