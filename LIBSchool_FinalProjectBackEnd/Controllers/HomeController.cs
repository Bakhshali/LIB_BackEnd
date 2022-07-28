using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using LIBSchool_FinalProjectBackEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM model = new HomeVM()
            {
                Settings = await _context.Settings.ToListAsync(),
                Sliders = await _context.Sliders.ToListAsync(),
                Categories = await _context.Categories.ToListAsync(),
                SubCategories = await _context.SubCategories.ToListAsync(),
                Courses = await _context.Courses.ToListAsync(),
                Quizzes = await _context.Quizzes.ToListAsync(),
            };
            return View(model);
        }
    }
}
