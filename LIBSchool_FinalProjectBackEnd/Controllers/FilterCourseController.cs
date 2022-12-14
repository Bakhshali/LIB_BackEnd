using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Controllers
{
    public class FilterCourseController : Controller
    {
        private readonly AppDbContext _context;

        public FilterCourseController(AppDbContext context)
        {
           _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM model = new HomeVM
            {
                Courses = await _context.Courses.ToListAsync(),
                CourseEducations = await _context.CourseEducations.ToListAsync(),
            };
            return View(model);
        }
    }
}
