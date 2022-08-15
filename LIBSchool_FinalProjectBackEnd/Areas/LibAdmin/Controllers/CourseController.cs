using LIBSchool_FinalProjectBackEnd.Areas.LibAdmin.Extensions;
using LIBSchool_FinalProjectBackEnd.Areas.LibAdmin.Utilities;
using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using LIBSchool_FinalProjectBackEnd.ViewModels;
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
            HomeVM model = new HomeVM
            {
                Courses = await _context.Courses.ToListAsync(),
                CourseEducations = await _context.CourseEducations.ToListAsync(),
            };
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();

            //ViewBag.Prices = await _context.CourseEducations.ToListAsync();

            ViewBag.Education = await _context.Educations.ToListAsync();
            Course courses = await _context.Courses.Include(c=>c.CourseEducations).FirstOrDefaultAsync();
            return View(courses);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(Course course)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();

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
            List<CourseEducation> courses = await _context.CourseEducations.ToListAsync();
            if (course == null) return NotFound();
            return View(course);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            Course course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();
            return View(course);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(Course course)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();

            Course existedCourse = await _context.Courses.FirstOrDefaultAsync(c => c.Id == course.Id);

            if (existedCourse == null) return NotFound();

            existedCourse.Name = course.Name;
            existedCourse.SubName = course.SubName;
           
            existedCourse.CategoryId = course.CategoryId;
            existedCourse.BelongText = course.BelongText;
            existedCourse.BelongTitle = course.BelongTitle;
            existedCourse.Condition = course.Condition;
            existedCourse.İnformation = course.İnformation;

            if (course.Photo != null)
            {
                if (course.Photo.IsOkay(1))
                {
                    existedCourse.Image = await course.Photo.FileCreate(_env.WebRootPath, @"assets\img\courses");
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
