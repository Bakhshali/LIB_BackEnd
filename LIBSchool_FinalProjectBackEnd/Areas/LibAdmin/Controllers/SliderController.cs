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
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Slider  slider)
        {
            if (!ModelState.IsValid)  return View();

            if (slider.Photo!=null)
            {
                if (!slider.Photo.IsOkay(1))
                {
                    ModelState.AddModelError("Photo", "Seçdiyiniz şəkil düzgün formatda deyil(başqa şəkil seçin)!");
                    return View();
                }

                slider.Image = await slider.Photo.FileCreate(_env.WebRootPath, @"assets\img\slider\");
            }
            else
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil seçin*");
                return View();
            }

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) return View();
            return View(slider);
             
        }

        public async Task<IActionResult> Edit(int id)
        {
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) return View();
            return View(slider);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            Slider existedSlider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == slider.Id);

            if (slider.Id != existedSlider.Id) return BadRequest();
            if (existedSlider == null) return NotFound();

            existedSlider.Title = slider.Title;
            existedSlider.Subtitle = slider.Subtitle;

            if (slider.Photo != null)
            {
                if (slider.Photo.IsOkay(1))
                {
                    existedSlider.Image = await slider.Photo.FileCreate(_env.WebRootPath, @"assets\img\slider");
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

        public async Task<IActionResult> Delete (int id)
        {
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) return View();
            return View(slider);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteSlider(Slider slider,int id)
        {
            Slider existedSlider = await _context.Sliders.FirstOrDefaultAsync(d => d.Id == id);

            if (existedSlider == null) return NotFound();

            string path = Path.Combine (_env.WebRootPath, @"assets\img\slider" , existedSlider.Image);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _context.Remove(existedSlider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
