using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Controllers
{
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM model = new HomeVM
            {
                Categories = await _context.Categories.ToListAsync(),
                Courses = await _context.Courses.ToListAsync(),
                Branches = await _context.Branches.ToListAsync(),
                CourseEducations = await _context.CourseEducations.ToListAsync(),
            };
            return View(model);
        }
    }
}
