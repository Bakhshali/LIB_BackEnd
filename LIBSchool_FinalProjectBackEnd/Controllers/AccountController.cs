using LIBSchool_FinalProjectBackEnd.Models;
using LIBSchool_FinalProjectBackEnd.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(SignInManager<AppUser> signInManager,UserManager<AppUser> userManager)
        {
           _signInManager = signInManager;
           _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = new AppUser
            {
                UserName = register.Username,
                Email = register.Email,
                Surname = register.Surname,
                Name = register.Name,

            };

            if (register.IsCondition)
            {
                IdentityResult result = await _userManager.CreateAsync(user, register.Password);
                if (!result.Succeeded)
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Sozlesmeyi qebul edin");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = await _userManager.FindByNameAsync(login.Username);

            if (user == null)
            {
                return NotFound();
            }

            if (login.RememberMe == true)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, true, true);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Username ve ya Password yanlisdir");
                    return View();
                }


            }
            else
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, false, true);

                if (!result.Succeeded)
                {
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("", "Sifreni 3 defe yanlis girdyiniz ucun 1 deq lik bloklandiniz!");
                        return View();
                    }
                    ModelState.AddModelError("", "Username ve ya Password yanlisdir");
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");

        }

       
       
        //public async Task<IActionResult> Edit()
        //{
        //    AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

        //    if (user == null) return NotFound();

        //    EditUserVM edit = new EditUserVM
        //    {
        //       Name = user.Name,
        //       Username = user.UserName,
        //       Email = user.Email,
        //       Surname = user.Surname,
        //    };

        //    return View(edit);
        //}


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

       
    }
}
