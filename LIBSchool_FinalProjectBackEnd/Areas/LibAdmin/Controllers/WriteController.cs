using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Areas.LibAdmin.Controllers
{
    [Area("LibAdmin")]
    public class WriteController : Controller
    {
        private readonly AppDbContext _context;

        public WriteController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Writeus> writeus = await _context.Writeus.ToListAsync();
            return View(writeus);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Writeus writeus = await _context.Writeus.FindAsync(id);
            if(writeus==null) return NotFound();
            return View(writeus);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Writeus writeus = await _context.Writeus.FirstOrDefaultAsync(c => c.Id == id);
            if (writeus == null) return View();
            return View(writeus);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteQuestion(int id)
        {
            Writeus existedWrite = await _context.Writeus.FirstOrDefaultAsync(d => d.Id == id);

            if (existedWrite == null) return NotFound();

            _context.Remove(existedWrite);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
