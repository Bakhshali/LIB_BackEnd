using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using LIBSchool_FinalProjectBackEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
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
            Category category = await _context.Categories.FirstOrDefaultAsync();
            if (course == null) return NotFound();

            ViewBag.Education = await _context.Educations.ToListAsync();

            HomeVM model = new HomeVM()
            {
                Categories = await _context.Categories.ToListAsync(),
                Courses = await _context.Courses.Include(s=>s.CourseEducations).ThenInclude(c=>c.Education).ToListAsync(),
                Course = course,
                Category = category,
                CourseEducations = await _context.CourseEducations.ToListAsync(),
                CourseEducation = await _context.CourseEducations.FirstOrDefaultAsync(),
                Educations = await _context.Educations.ToListAsync(),
            };
            return View(model);
        }
    }
}

