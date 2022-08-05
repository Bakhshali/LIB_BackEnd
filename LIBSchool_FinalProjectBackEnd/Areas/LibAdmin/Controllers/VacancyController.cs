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
    public class VacancyController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public VacancyController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Career> careers = await _context.Careers.ToListAsync();
            return View(careers);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Career career = await _context.Careers.FindAsync(id);
            if(career==null) return NotFound();
            return View(career);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Career career = await _context.Careers.FirstOrDefaultAsync(c => c.Id == id);
            if (career == null) return View();
            return View(career);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteVacancy(int id)
        {
            Career existedVacancy = await _context.Careers.FirstOrDefaultAsync(d => d.Id == id);

            if (existedVacancy == null) return NotFound();

            string path = Path.Combine(_env.WebRootPath, @"assets\img\cv", existedVacancy.Image);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _context.Remove(existedVacancy);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
