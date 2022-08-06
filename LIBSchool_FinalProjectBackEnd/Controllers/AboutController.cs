using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using LIBSchool_FinalProjectBackEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index (bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;

            HomeVM model = new HomeVM()
            {
                Students = await _context.Students.ToListAsync(),
                Results = await _context.Results.ToListAsync(),
                Teams = await _context.Teams.ToListAsync(),
                Settings = await _context.Settings.ToListAsync(),
                Sliders = await _context.Sliders.ToListAsync(),
                Categories = await _context.Categories.ToListAsync(),
                SubCategories = await _context.SubCategories.ToListAsync(),
                Courses = await _context.Courses.ToListAsync(),
                Quizzes = await _context.Quizzes.ToListAsync(),
            };
            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index (Writeus writeus)
        {
            HomeVM model = new HomeVM()
            {
                Students = await _context.Students.ToListAsync(),
                Results = await _context.Results.ToListAsync(),
                Teams = await _context.Teams.ToListAsync(),
                Settings = await _context.Settings.ToListAsync(),
                Sliders = await _context.Sliders.ToListAsync(),
                Categories = await _context.Categories.ToListAsync(),
                SubCategories = await _context.SubCategories.ToListAsync(),
                Courses = await _context.Courses.ToListAsync(),
                Quizzes = await _context.Quizzes.ToListAsync(),
            };

            if (!ModelState.IsValid)
            {
                var message = false;

                foreach(var modelstate in ViewData.ModelState.Values)
                {
                    if (message)
                    {
                        modelstate.Errors.Clear();
                    }
                    if (modelstate.Errors.Count > 0)
                    {
                        message = true;
                    }

                    if (modelstate.Errors.Count > 1)
                    {
                        var firstError = modelstate.Errors.First();
                        modelstate.Errors.Clear();
                        modelstate.Errors.Add(firstError);
                    }

                }
                return View(model);

            }
            
      
            await _context.Writeus.AddAsync(writeus);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { IsSuccess = true});
        }
    }
}
