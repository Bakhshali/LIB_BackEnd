using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using LIBSchool_FinalProjectBackEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(bool isSuccess = false)
        {
           ViewBag.IsSuccess = isSuccess;
            HomeVM model = new HomeVM
            {
                Branches = await _context.Branches.ToListAsync(),
                Contacts = await _context.Contacts.ToListAsync(),
            };
            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Index(Contact contact)
        {
            HomeVM model = new HomeVM
            {
                Branches = await _context.Branches.ToListAsync(),
            };
           
            if (!ModelState.IsValid) return View(model);

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { IsSuccess = true });
        }
    }
}
