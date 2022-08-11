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

        public async Task<IActionResult> Index(bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;

            HomeVM model = new HomeVM()
            {
                Settings = await _context.Settings.ToListAsync(),
                Sliders = await _context.Sliders.ToListAsync(),
                Categories = await _context.Categories.ToListAsync(),
                SubCategories = await _context.SubCategories.ToListAsync(),
                Courses = await _context.Courses.ToListAsync(),
                Quizzes = await _context.Quizzes.ToListAsync(),
                Branches = await _context.Branches.ToListAsync(),
                QuizInfos = await _context.QuizInfos.ToListAsync(),
                QuizTeachers = await _context.QuizTeachers.ToListAsync(),
                QuizTimes = await _context.QuizTimes.ToListAsync(),
                CourseEducations = await _context.CourseEducations.ToListAsync(),
            };
            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Index(Special special)
        {
            HomeVM model = new HomeVM
            {
                Settings = await _context.Settings.ToListAsync(),
                Sliders = await _context.Sliders.ToListAsync(),
                Categories = await _context.Categories.ToListAsync(),
                SubCategories = await _context.SubCategories.ToListAsync(),
                Courses = await _context.Courses.ToListAsync(),
                Quizzes = await _context.Quizzes.ToListAsync(),
                Branches = await _context.Branches.ToListAsync(),
                QuizInfos = await _context.QuizInfos.ToListAsync(),
                QuizTeachers = await _context.QuizTeachers.ToListAsync(),
                QuizTimes = await _context.QuizTimes.ToListAsync(),
            };
            if (!ModelState.IsValid) return View(model);

            await _context.Specials.AddAsync(special);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { IsSuccess = true });
        }
    }
}
