using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Areas.LibAdmin.Controllers
{
    [Area("LibAdmin")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;

        public SettingController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Setting> settings = await _context.Settings.ToListAsync();
            return View(settings);
        }

        public async Task<IActionResult> Details(int id)
        {
            Setting setting = await _context.Settings.FirstOrDefaultAsync(x => x.Id == id);
            if(setting==null) return NotFound();
            return View(setting);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Setting setting = await _context.Settings.FirstOrDefaultAsync(x => x.Id == id);
            if (setting == null) return NotFound();
            return View(setting);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(Setting setting,int id)
        {
            if (!ModelState.IsValid) return View();
            Setting existedSetting = await _context.Settings.FirstOrDefaultAsync(x => x.Id == setting.Id);
            if (existedSetting==null) return NotFound();
            if(id!=existedSetting.Id) return BadRequest();

            existedSetting.Value = setting.Value;
            existedSetting.URL = setting.URL;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
