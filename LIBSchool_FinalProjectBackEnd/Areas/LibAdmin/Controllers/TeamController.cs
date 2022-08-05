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

namespace LIBSchool_FinalProjectBackEnd.Controllers
{
    [Area("LibAdmin")]

    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeamController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Team> teams = await _context.Teams.ToListAsync();
            return View(teams);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(Team team)
        {
            if (!ModelState.IsValid) return View();

            if (team.Photo != null)
            {
                if (!team.Photo.IsOkay(1))
                {
                    ModelState.AddModelError("Photo", "Seçdiyiniz şəkil düzgün formatda deyil(başqa şəkil seçin)!");
                    return View();
                }

                team.Image = await team.Photo.FileCreate(_env.WebRootPath, @"assets\img\whyus\");

            }
            else
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil seçin*");
                return View();
            }

            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            Team team = await _context.Teams.FindAsync(id);
            if(team==null) return NotFound();
            return View(team);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(Team team,int id)
        {
            if (!ModelState.IsValid) return View();

            Team existedTeam = await _context.Teams.FirstOrDefaultAsync(x => x.Id == team.Id);
            if (existedTeam==null) return NotFound();
            if(id!=existedTeam.Id) return BadRequest();

            string path = Path.Combine(_env.WebRootPath, @"assets\img\whyus", existedTeam.Image);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            if (team.Photo != null)
            {
                if (team.Photo.IsOkay(1))
                {
                    existedTeam.Image = await team.Photo.FileCreate(_env.WebRootPath, @"assets\img\whyus");
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
            Team team = await _context.Teams.FindAsync(id);
            if (team == null) return NotFound();
            return View(team);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteTeam(int id)
        {
            Team existedTeam = await _context.Teams.FindAsync(id);
            if(existedTeam==null) return NotFound();

            string path = Path.Combine(_env.WebRootPath, @"assets\img\whyus", existedTeam.Image);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _context.Teams.Remove(existedTeam);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
