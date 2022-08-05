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
    public class ResultController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ResultController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Student> students = await _context.Students.Include(r => r.Result).ToListAsync();
            return View(students);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Results = await _context.Results.ToListAsync();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(Student student)
        {
            ViewBag.Results = await _context.Results.ToListAsync();

            if (!ModelState.IsValid) return View();

            if (student.Photo != null)
            {
                if (!student.Photo.IsOkay(1))
                {
                    ModelState.AddModelError("Photo", "Seçdiyiniz şəkil düzgün formatda deyil(başqa şəkil seçin)!");
                    return View();
                }

                student.ResultImage = await student.Photo.FileCreate(_env.WebRootPath, @"assets\img\result\");
            }
            else
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil seçin*");
                return View();
            }

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            Student student = await _context.Students.Include(r => r.Result).FirstOrDefaultAsync(c => c.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Results = await _context.Results.ToListAsync();
            Student student = await _context.Students.Include(c=>c.Result).FirstOrDefaultAsync(c=>c.Id==id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(Student student,int id)
        {
            ViewBag.Results = await _context.Results.ToListAsync();
            Student existedStudent = await _context.Students.FirstOrDefaultAsync(c => c.Id == id);
            if (existedStudent == null) return NotFound();

            existedStudent.Name = student.Name;
            existedStudent.Surname = student.Surname;
            existedStudent.ResultId = student.ResultId;


            if (student.Photo != null)
            {
                if (student.Photo.IsOkay(1))
                {
                    existedStudent.ResultImage = await student.Photo.FileCreate(_env.WebRootPath, @"assets\img\result");
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
            Student student = await _context.Students.Include(c=>c.Result).FirstOrDefaultAsync(s => s.Id == id);
            if (student == null) return View();
            return View(student);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteSlider(int id)
        {
            Student existedStudent = await _context.Students.FirstOrDefaultAsync(d => d.Id == id);

            if (existedStudent == null) return NotFound();

            string path = Path.Combine(_env.WebRootPath, @"assets\img\result", existedStudent.ResultImage);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _context.Remove(existedStudent);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
