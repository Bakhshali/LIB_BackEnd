using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using LIBSchool_FinalProjectBackEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Controllers
{
    public class DetailController : Controller
    {
        private readonly AppDbContext _context;

        public DetailController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int id) 
        {
            Course course = await _context.Courses.FirstOrDefaultAsync(d => d.Id == id);
            if (course == null) return NotFound();

            HomeVM model = new HomeVM()
            {
                Settings = await _context.Settings.ToListAsync(),
                Sliders = await _context.Sliders.ToListAsync(),
                Categories = await _context.Categories.ToListAsync(),
                SubCategories = await _context.SubCategories.ToListAsync(),
                Courses = await _context.Courses.ToListAsync(),
                Course = course,
                Quizzes = await _context.Quizzes.ToListAsync(),
            };
            return View(model);
        }
    }
}
