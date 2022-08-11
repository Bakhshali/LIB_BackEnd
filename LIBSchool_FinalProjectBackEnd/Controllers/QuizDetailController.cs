using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using LIBSchool_FinalProjectBackEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Controllers
{
    public class QuizDetailController : Controller
    {
        private readonly AppDbContext _context;

        public QuizDetailController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            QuizInfo info = await _context.QuizInfos.FirstOrDefaultAsync(d => d.Id == id);

            HomeVM model = new HomeVM
            {
                QuizInfo = info,
                QuizTimes = await _context.QuizTimes.ToListAsync(),
                QuizTeachers = await _context.QuizTeachers.ToListAsync(),
            };

            return View(model);
        }
    }
}
