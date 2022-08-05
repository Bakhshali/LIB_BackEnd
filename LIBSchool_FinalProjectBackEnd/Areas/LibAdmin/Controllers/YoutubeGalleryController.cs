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
    public class YoutubeGalleryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public YoutubeGalleryController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Gallery> galleries = await _context.Galleries.ToListAsync();
            return View(galleries);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(Gallery gallery)
        {
            if (!ModelState.IsValid) return View();


            if (gallery.Photo != null)
            {
                if (!gallery.Photo.IsOkay(1))
                {
                    ModelState.AddModelError("Photo", "Seçdiyiniz şəkil düzgün formatda deyil(başqa şəkil seçin)!");
                    return View();
                }

                gallery.YoutubeImage = await gallery.Photo.FileCreate(_env.WebRootPath, @"assets\img\thumbnail\");

            }
            else
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil seçin*");
                return View();
            }

            await _context.Galleries.AddAsync(gallery);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            Gallery gallery = await _context.Galleries.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }
            return View(gallery);
        }


        public async Task<IActionResult> Edit(int id)
        {
            Gallery gallery = await _context.Galleries.FindAsync(id);
            if (gallery==null)
            {
                return NotFound();
            }
            return View(gallery);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(Gallery gallery,int id)
        {
            if (!ModelState.IsValid) return View();

            Gallery existedGallery = await _context.Galleries.FirstOrDefaultAsync(c => c.Id == gallery.Id);
            if (existedGallery == null) return NotFound();
            if (id != existedGallery.Id) return BadRequest();

            existedGallery.Title = gallery.Title;
            existedGallery.URL = gallery.URL;

            string path = Path.Combine(_env.WebRootPath, @"assets\img\thumbnail", existedGallery.YoutubeImage);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            if (gallery.Photo != null)
            {
                if (gallery.Photo.IsOkay(1))
                {
                    existedGallery.YoutubeImage = await gallery.Photo.FileCreate(_env.WebRootPath, @"assets\img\thumbnail");
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
            Gallery gallery = await _context.Galleries.FindAsync(id);
            if (gallery == null) return NotFound();
            return View(gallery);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteGallery(int id)
        {
            Gallery existedGalery = await _context.Galleries.FindAsync(id);
            if (existedGalery == null) return NotFound();

            string path = Path.Combine(_env.WebRootPath, @"assets\img\thumbnail", existedGalery.YoutubeImage);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _context.Galleries.Remove(existedGalery);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
