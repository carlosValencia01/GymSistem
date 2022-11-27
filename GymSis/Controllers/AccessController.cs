using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using GymSis.Models;
using GymSis.Data;

namespace GymSis.Controllers
{
    public class AccessController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AccessController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated) 
            {
                return RedirectToAction("Index", "Home");
            }


            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(Gym modelLogin)
        {
            //TODO-solo hacer el post si los campos tienen datos

            List<Gym> gyms = _db.Gyms.ToList();
            
            var gymObj = gyms.Where(x => x.Email == modelLogin.Email && x.Password == modelLogin.Password).ToList();


            if (gymObj.Count > 0)
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                    new Claim("OtherProperties","Example Role")
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme
                    );

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties
                    );
                return RedirectToAction("Index", "Home");

            }
            else if (modelLogin.Email != null && modelLogin.Password != null)
            {
                ViewData["ValidateMessage"] = "Usuario y/o contraseña incorrecto";
                return View();
            }
            else
            {           
                return View();
            }
        }
    }
}
