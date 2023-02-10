using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SC.WebApp.Models;
using System.Security.Claims;

namespace SC.WebApp.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!(model.Email == "xyz@gmail.com" && model.Password == "987654321"))
            {
                return RedirectToAction(nameof(Login));
            }
            try
            { 
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email)
            };
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);

            return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await this.HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
