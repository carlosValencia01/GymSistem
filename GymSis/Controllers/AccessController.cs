using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using GymSis.Models;
using GymSis.Data;
using Microsoft.EntityFrameworkCore;


namespace GymSis.Controllers
{
    public class AccessController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AccessController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public Gym Gym { get; set; }        
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated) 
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult ResetPassword()
        {            
            return View();
        }

            public async Task<IActionResult> OnPostResetPassword(Gym obj)
            {
            if (obj.Email == null) {
                return View();
            }
            Gym = await _db.Gyms.FirstOrDefaultAsync(m => m.Email == obj.Email);

            if (Gym == null)
            {
                //todo-usuario no encontrado alert
                
                
                return RedirectToAction("ResetPassword");
            }
            Gym.Password = Services.CodeGenerator.generateCode();
            //TODO-Enviar mail
            _db.Gyms.Update(Gym);                     
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GymExists(Gym.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //TODO-Mostrar alert de que se reseteo la contraseña
            return RedirectToAction("Login");
        }

        private bool GymExists(int id)
        {
            return _db.Gyms.Any(e => e.Id == id);
        }

        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostCreate(Gym obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
                _db.Gyms.Add(obj);
                await _db.SaveChangesAsync();
            //TODO-Mostrar alert de que ya se registro
                return RedirectToAction("Login");
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyEmail(string email)
        {            
            if (!IsEmailAvailable(email))
            {
                return Json($"Email {email} ya ha sido registrado.");
            }
            return Json(true);
        }


        public bool IsEmailAvailable(string Tag)
        {           
                try
                {
                    var tag = _db.Gyms.Single(m => m.Email == Tag);
                return false;
                }
                catch (Exception)
                {
                return true;
                }            
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
