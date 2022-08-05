using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Areas.LibAdmin.Controllers
{
    [Area("LibAdmin")]
    public class PointExamController : Controller
    {
        private readonly AppDbContext _context;

        public PointExamController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Result> results = await _context.Results.ToListAsync();
            return View(results);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(Result result)
        {
            if (!ModelState.IsValid) return View();

            await _context.Results.AddAsync(result);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            Result result = await _context.Results.FindAsync(id);
            if (result == null) return NotFound();
            return View(result);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(Result result,int id)
        {
            Result existedResult = await _context.Results.FirstOrDefaultAsync(c=>c.Id==result.Id);
            if (existedResult == null) return NotFound();
            if (id != existedResult.Id) return BadRequest();

            _context.Entry(existedResult).CurrentValues.SetValues(result);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            Result result = await _context.Results.FindAsync(id);
            if (result == null) return NotFound();
            return View(result);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteResult(int id)
        {
            Result existedResult = await _context.Results.FirstOrDefaultAsync(c => c.Id == id);
            Student student = await _context.Students.FindAsync(id);
            if(existedResult==null) return NotFound();

            _context.Results.Remove(existedResult);

            //if (existedResult.Id!=student.ResultId)
            //{
            //    _context.Results.Remove(existedResult);
            //}
            //else
            //{

            //    ModelState.AddModelError("", "Silmek mumkun olmadi!");
            //    return View();
            //}
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
