using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Areas.LibAdmin.Controllers
{
    [Area("LibAdmin")]
    public class BranchController : Controller
    {
        private readonly AppDbContext _context;

        public BranchController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Branch> branches = await _context.Branches.ToListAsync();
            return View(branches);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(Branch branch)
        {
            if (!ModelState.IsValid) return View();

            await _context.Branches.AddAsync(branch);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            Branch branch = await _context.Branches.FindAsync(id);
            if (branch == null) return NotFound();
            return View(branch);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Branch branch = await _context.Branches.FindAsync(id);
            if (branch == null) return NotFound();
            return View(branch);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(Branch branch)
        {
            Branch existedBranch = await _context.Branches.FirstOrDefaultAsync(e => e.Id == branch.Id);
            if (existedBranch == null) return NotFound();

            _context.Entry(existedBranch).CurrentValues.SetValues(branch);

            if (!ModelState.IsValid) return View();

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            Branch branch = await _context.Branches.FindAsync(id);
            if (branch == null) return NotFound();
            return View(branch);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteBranch(int id)
        {
            Branch existedbranch = await _context.Branches.FirstOrDefaultAsync(e => e.Id == id);
            if (existedbranch == null) return NotFound();

            _context.Remove(existedbranch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}
