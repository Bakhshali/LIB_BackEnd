using LIBSchool_FinalProjectBackEnd.Areas.LibAdmin.Extensions;
using LIBSchool_FinalProjectBackEnd.Areas.LibAdmin.Utilities;
using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Areas.LibAdmin.Controllers
{
    [Area("LibAdmin")]
    public class QuizController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public QuizController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public async Task<IActionResult> Index()
        {
            List<QuizInfo> quiz = await _context.QuizInfos.Include(q => q.QuizTime).ToListAsync();
            return View(quiz);
        }

        public async Task<IActionResult> Detail(int id)
        {
            QuizInfo quiz = await _context.QuizInfos.Include(s => s.QuizTime).Include(t => t.QuizTeacher).FirstOrDefaultAsync(s => s.Id == id);
            if (quiz == null) return NotFound();
            return View(quiz);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Time = await _context.QuizTimes.ToListAsync();
            ViewBag.Teacher = await _context.QuizTeachers.ToListAsync();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(QuizInfo quiz)
        {
            ViewBag.Time = await _context.QuizTimes.ToListAsync();
            ViewBag.Teacher = await _context.QuizTeachers.ToListAsync();

            if (!ModelState.IsValid) return View();

            if (quiz.Photo != null)
            {
                if (!quiz.Photo.IsOkay(1))
                {
                    ModelState.AddModelError("Photo", "Seçdiyiniz şəkil düzgün formatda deyil(başqa şəkil seçin)!");
                    return View();
                }

                quiz.Image = await quiz.Photo.FileCreate(_env.WebRootPath, @"assets\img\quiz-time\");
            }
            else
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil seçin*");
                return View();
            }

            await _context.QuizInfos.AddAsync(quiz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Time = await _context.QuizTimes.ToListAsync();
            ViewBag.Teacher = await _context.QuizTeachers.ToListAsync();

            QuizInfo quiz = await _context.QuizInfos.FindAsync(id);
            if (quiz == null) return NotFound();
            return View(quiz);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(QuizInfo quiz, int id)
        {
            ViewBag.Time = await _context.QuizTimes.ToListAsync();
            ViewBag.Teacher = await _context.QuizTeachers.ToListAsync();

            if (!ModelState.IsValid) return View();

            QuizInfo existedQuizInfo = await _context.QuizInfos.FirstOrDefaultAsync(c => c.Id == quiz.Id);
            if (existedQuizInfo == null) return NotFound();
            if (id != existedQuizInfo.Id) return BadRequest();

            existedQuizInfo.Name = quiz.Name;
            existedQuizInfo.Question = quiz.Question;
            existedQuizInfo.Listener = quiz.Listener;
            existedQuizInfo.QuizTeacherId = quiz.QuizTeacherId;
            existedQuizInfo.QuizTimeId = quiz.QuizTimeId;

            string path = Path.Combine(_env.WebRootPath, @"assets\img\quiz-time", existedQuizInfo.Image);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            if (quiz.Photo != null)
            {
                if (quiz.Photo.IsOkay(1))
                {
                    existedQuizInfo.Image = await quiz.Photo.FileCreate(_env.WebRootPath, @"assets\img\quiz-time");
                }
                else
                {
                    ModelState.AddModelError("Photo", "Seçdiyiniz şəkil düzgün formatda deyil(başqa şəkil seçin)!");
                    return View();
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            QuizInfo quiz = await _context.QuizInfos.Include(s=>s.QuizTeacher).Include(t=>t.QuizTime).FirstOrDefaultAsync(q=>q.Id==id);
            if (quiz == null) return NotFound();
            return View(quiz);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteQuizInfo(int id)
        {
            QuizInfo existedQuiz = await _context.QuizInfos.FindAsync(id);
            if (existedQuiz == null) return NotFound();

            string path = Path.Combine(_env.WebRootPath, @"assets\img\quiz-time", existedQuiz.Image);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _context.QuizInfos.Remove(existedQuiz);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
