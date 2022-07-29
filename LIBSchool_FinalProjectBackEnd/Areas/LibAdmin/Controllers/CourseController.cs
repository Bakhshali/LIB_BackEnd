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
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CourseController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Course> courses = await _context.Courses.ToListAsync();
            return View(courses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(Course course)
        {
            if (!ModelState.IsValid) return View();

            if (course.Photo != null)
            {
                if (!course.Photo.IsOkay(1))
                {
                    ModelState.AddModelError("Photo", "Seçdiyiniz şəkil düzgün formatda deyil(başqa şəkil seçin)!");
                    return View();
                }

                course.Image = await course.Photo.FileCreate(_env.WebRootPath, @"assets\img\courses\");
            }
            else
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil seçin*");
                return View();
            }

            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            Course course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();
            return View(course);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Course course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();
            return View(course);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(Course course)
        {
            Course existedCourse = await _context.Courses.FirstOrDefaultAsync(c => c.Id == course.Id);
            if (existedCourse == null) return NotFound();

            _context.Entry(existedCourse).CurrentValues.SetValues(course);

            if (course.Photo != null)
            {
                if (course.Photo.IsOkay(1))
                {
                    existedCourse.Image = await course.Photo.FileCreate(_env.WebRootPath, @"assets\img\slider");
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
            Course course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();
            return View(course);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteCourse(int id)
        {
            Course existedCourse = await _context.Courses.FirstOrDefaultAsync(d => d.Id == id);

            if (existedCourse == null) return NotFound();

            string path = Path.Combine(_env.WebRootPath, @"assets\img\courses", existedCourse.Image);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _context.Remove(existedCourse);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
