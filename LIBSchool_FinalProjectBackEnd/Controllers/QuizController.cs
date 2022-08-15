using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Controllers
{
    public class QuizController : Controller
    {
        private readonly AppDbContext _context;

        public QuizController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult>  Index()
        {          
            HomeVM model = new HomeVM
            {
                Questions = await _context.Questions.Include(c=>c.Answers).ToListAsync(),
                Answers = await _context.Answers.Include(c=>c.Question).ToListAsync(),
            };
            return View(model);
        }
    }
}
