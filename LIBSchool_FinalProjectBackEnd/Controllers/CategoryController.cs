using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using LIBSchool_FinalProjectBackEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id,int categories, string searchCourse)
        {
            List<Course> courses = await _context.Courses.Where(c => c.Name.Contains(searchCourse)).ToListAsync();

            ViewBag.Search = searchCourse;
            Category category = await _context.Categories.FindAsync(id);
            Course course = await _context.Courses.FirstOrDefaultAsync();
            ViewBag.Categories = categories;


            if (category == null) return NotFound();


            HomeVM model = new HomeVM()
            {
                Writeuss = await _context.Writeus.ToListAsync(),
                Settings = await _context.Settings.ToListAsync(),
                Contacts = await _context.Contacts.ToListAsync(),
                Careerss = await _context.Careers.ToListAsync(),
                Sliders = await _context.Sliders.ToListAsync(),
                Categories = await _context.Categories.ToListAsync(),
                SubCategories = await _context.SubCategories.ToListAsync(),
                Courses = await _context.Courses.ToListAsync(),
                Branches = await _context.Branches.ToListAsync(),
                Category = category,
                Course = course,
                Quizzes = await _context.Quizzes.ToListAsync(),
            };
            return View(model);


        }
    }
}
