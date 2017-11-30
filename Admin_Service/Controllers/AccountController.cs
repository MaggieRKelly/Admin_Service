using Microsoft.AspNetCore.Mvc;
using Admin_Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using Admin_Service.Models;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Admin_Service.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Title = "Login Page";
            return View();
        }


        //private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        //public static string GenerateToken(string username,string  role,  int expireMinutes = 20)
        //{
        //    var symmetricKey = Convert.FromBase64String(Secret);
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var now = DateTime.UtcNow;
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        //This is adding bits to the token
        //        Subject = new ClaimsIdentity(new[]
        //                {
        //                new Claim(ClaimTypes.Name, username),
        //                new Claim(ClaimTypes.Role, role)
        //            }),

        //        Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),

        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var stoken = tokenHandler.CreateToken(tokenDescriptor);
        //    var token = tokenHandler.WriteToken(stoken);

        //    return token;
        //}

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, false);
                if (result.Succeeded)
                {
                    //This is me creating a token 
                    ///GenerateToken("persons name", "staff", 60);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Login Attempt.");
                return View(vm);
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Title = "Registration Page";
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = vm.Email, Email = vm.Email };
                var result = await _userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(vm);
        }

    }
}