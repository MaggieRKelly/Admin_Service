using Microsoft.AspNetCore.Mvc;
using Admin_Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using Admin_Service.Models;

namespace Admin_Service.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
       public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async IActionResult Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var user = new StaffLogin { UserName = vm.UserName, };
                var result = await _userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
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