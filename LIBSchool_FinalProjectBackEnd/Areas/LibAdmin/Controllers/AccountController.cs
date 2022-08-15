using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Areas.LibAdmin.Controllers
{
    [Area("LibAdmin")]

    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(AppDbContext context,SignInManager<AppUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public async Task<IActionResult>  Index()
        {
            List<AppUser> user = await _context.AppUsers.ToListAsync();
            return View(user);
        }

        public async Task<IActionResult>Edit(string id)
        {
            AppUser user = await _context.AppUsers.FindAsync(id);
            return View(user);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(AppUser user)
        {
            if(!ModelState.IsValid) return View();

            AppUser existerUser = await _context.AppUsers.FirstOrDefaultAsync(s => s.Id == user.Id);
            if(existerUser == null) return NotFound();
                
            existerUser.Name = user.Name;
            existerUser.Surname = user.Surname;

            if (user.IsBlock==true)
            {
                await _signInManager.SignOutAsync();
                existerUser.IsBlock = false;
            }
            else if(user.IsBlock==false)
            {
                    existerUser.IsBlock=true;
            }

            existerUser.IsBlock = user.IsBlock;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}
