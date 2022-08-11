using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Areas.LibAdmin.Controllers
{
    [Area("LibAdmin")]
    public class SpecialyController : Controller
    {
        private readonly AppDbContext _context;

        public SpecialyController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Special> specials = await _context.Specials.ToListAsync();
            return View(specials);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Special special = await _context.Specials.FindAsync(id);
            if(special==null) return NotFound();
            return View(special);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteEmail(int id)
        {
            Special existedSpecial = await _context.Specials.FirstOrDefaultAsync(d => d.Id == id);

            if (existedSpecial == null) return NotFound();

            _context.Remove(existedSpecial);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
