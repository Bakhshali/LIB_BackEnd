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
    public class AlbumController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AlbumController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Album> albums = await _context.Albums.ToListAsync();
            return View(albums);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(Album album)
        {
            if (!ModelState.IsValid) return View();

            if (album.Photo != null)
            {
                if (!album.Photo.IsOkay(1))
                {
                    ModelState.AddModelError("Photo", "Seçdiyiniz şəkil düzgün formatda deyil(başqa şəkil seçin)!");
                    return View();
                }

                album.Image = await album.Photo.FileCreate(_env.WebRootPath, @"assets\img\photoalbum\");

            }
            else
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil seçin*");
                return View();
            }

            await _context.Albums.AddAsync(album);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            Album album = await _context.Albums.FindAsync(id);
            if (album == null) return NotFound();
            return View(album);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(Album album, int id)
        {
            if (!ModelState.IsValid) return View();

            Album existedAlbum = await _context.Albums.FirstOrDefaultAsync(x => x.Id == album.Id);
            if (existedAlbum == null) return NotFound();
            if (id != existedAlbum.Id) return BadRequest();

            string path = Path.Combine(_env.WebRootPath, @"assets\img\photoalbum", existedAlbum.Image);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            if (album.Photo != null)
            {
                if (album.Photo.IsOkay(1))
                {
                    existedAlbum.Image = await album.Photo.FileCreate(_env.WebRootPath, @"assets\img\photoalbum");
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
            Album album = await _context.Albums.FindAsync(id);
            if (album == null) return NotFound();
            return View(album);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteAlbum(int id)
        {
            Album existedAlbum = await _context.Albums.FindAsync(id);
            if (existedAlbum == null) return NotFound();

            string path = Path.Combine(_env.WebRootPath, @"assets\img\photoalbum", existedAlbum.Image);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _context.Albums.Remove(existedAlbum);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}
