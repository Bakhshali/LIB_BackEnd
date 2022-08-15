using LIBSchool_FinalProjectBackEnd.Areas.LibAdmin.Extensions;
using LIBSchool_FinalProjectBackEnd.Areas.LibAdmin.Utilities;
using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Helpers;
using LIBSchool_FinalProjectBackEnd.Models;
using LIBSchool_FinalProjectBackEnd.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
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
                ModelState.AddModelError("", "Zəhmət olmasa sözləşməni qəbul edin");
                return View();
            }

            await _userManager.AddToRoleAsync(user, Helper.Member.ToString());

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string link = Url.Action(nameof(VerifyEmail), "Account", new { email = user.Email, token }, Request.Scheme, Request.Host.ToString());

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("tu78rfrfu@code.edu.az", "LibSchool");
            mail.To.Add(new MailAddress(user.Email));

            mail.Subject = "Verify Email";

            string body = string.Empty;

            using (StreamReader reader = new StreamReader("wwwroot/assets/template/verifyemail.html"))
            {
                body = reader.ReadToEnd();
            }
            string about = $"Welcome <strong>{user.Name} {user.Surname}</strong> to our course,please click the link in below to verify your account";

            body = body.Replace("{{link}}", link);
            mail.Body = body.Replace("{{about}}", about);
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential("tu78rfrfu@code.edu.az", "rhkwgjvxkezppfxr");

            smtp.Send(mail);

            TempData["Verify"] = true;

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> VerifyEmail(string email, string token)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);
            if (user == null) return BadRequest();

            await _userManager.ConfirmEmailAsync(user, token);
            await _signInManager.SignInAsync(user, true);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotVM forgot)
        {

            AppUser user = await _userManager.FindByEmailAsync(forgot.AppUser.Email);

            if (user == null) return BadRequest();

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string link = Url.Action(nameof(ResetPassword), "Account", new { email = user.Email, token }, Request.Scheme, Request.Host.ToString());

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("tu78rfrfu@code.edu.az", "LibSchool");
            mail.To.Add(new MailAddress(user.Email));

            mail.Subject = "Reset Password";
            mail.Body = $"<a href='{link}'>Please click here to reset your password</a>";
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential("tu78rfrfu@code.edu.az", "rhkwgjvxkezppfxr");
            smtp.Send(mail);

            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> ResetPassword(string email, string token)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);
            if (user == null) return BadRequest();

            ForgotVM model = new ForgotVM
            {
                AppUser = user,
                Token = token,
            };
            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> ResetPassword(ForgotVM forgot)
        {
            AppUser user = await _userManager.FindByEmailAsync(forgot.AppUser.Email);
            ForgotVM model = new ForgotVM
            {
                AppUser = user,
                Token = forgot.Token,
            };

            if (!ModelState.IsValid) return View(model);

            IdentityResult result = await _userManager.ResetPasswordAsync(user, forgot.Token, forgot.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = await _userManager.FindByNameAsync(login.Username);

            if (user == null)
            {
                ModelState.AddModelError("", "Username ve ya Password yanlisdir");
                return View();
            }

            IList<string> roles = await _userManager.GetRolesAsync(user);

            string role = roles.FirstOrDefault(r => r == Helper.Member.ToString());

            if (user.IsBlock == false)
            {

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
            }
            else
            {
                ModelState.AddModelError("", "Sizin girişiniz məhdudlaşdırılıb,zəhmət olmasa admin ilə əlaqə saxlayın");
                return View();
            }
            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> Edit()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null) return NotFound();

            EditUserVM edit = new EditUserVM
            {
                Name = user.Name,
                Username = user.UserName,
            };
            return View(edit);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(EditUserVM user)
        {


            AppUser existeduser = await _userManager.FindByNameAsync(User.Identity.Name);
            bool result = user.Password == null && user.ConfirmPassword == null && user.CurrentPassword != null;
            EditUserVM edit = new EditUserVM
            {
                Name = existeduser.Name,
                Username = existeduser.UserName,

            };
            if (!ModelState.IsValid) return View(edit);

            if (result)
            {
                existeduser.Name = user.Name;
                existeduser.UserName = user.Username;
                await _userManager.UpdateAsync(existeduser);

            }
            else
            {
                existeduser.Name = user.Name;
                existeduser.UserName = user.Username;

                if (user.CurrentPassword == user.Password)
                {
                    ModelState.AddModelError("", "You can not change password with the same password ");
                    return View();
                }
                IdentityResult resultEdit = await _userManager.ChangePasswordAsync(existeduser, user.CurrentPassword, user.Password);

                if (!resultEdit.Succeeded)
                {
                    foreach (IdentityError error in resultEdit.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(edit);
                }
            }
            return RedirectToAction("Index", "Home");
        }



        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public async Task CreateRole()
        {

            if (!await _roleManager.RoleExistsAsync(Helper.Admin.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(Helper.Admin.ToString()));
            }
            if (!await _roleManager.RoleExistsAsync(Helper.Member.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(Helper.Member.ToString()));
            }
            if (!await _roleManager.RoleExistsAsync(Helper.SuperAdmin.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(Helper.SuperAdmin.ToString()));
            }
        }
    }
}
