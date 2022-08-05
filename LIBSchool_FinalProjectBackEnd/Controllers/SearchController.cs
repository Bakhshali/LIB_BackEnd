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
    public class SearchController : Controller
    {
        private readonly AppDbContext _context;

        public SearchController(AppDbContext context)
        {
            _context = context;
        }

        public async Task <IActionResult> Index(string searchCourse)
        {
           ViewBag.Search = searchCourse;

            List<Course> courses = await _context.Courses.Where(c=>c.Name.Contains(searchCourse)).ToListAsync();
            List<Category> categories = await _context.Categories.ToListAsync();

            HomeVM model = new HomeVM
            {
                Courses = courses,
                Categories = categories,
                
            };
            return View(model);
        }
    }
}
