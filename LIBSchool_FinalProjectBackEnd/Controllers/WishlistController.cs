using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using LIBSchool_FinalProjectBackEnd.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Controllers
{
    public class WishlistController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public WishlistController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            HomeVM model = new HomeVM
            {
                Courses = await _context.Courses.ToListAsync(),
                WishlistItems = await _context.Wishlists.ToListAsync(),
            };
            return View(model);
        }


        [Authorize]
        public async Task<IActionResult> AddWishlist(int id)
        {

            Course course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return NotFound();


            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            WishlistItem basketItem = await _context.Wishlists.FirstOrDefaultAsync(b => b.AppUserId == user.Id && b.CourseId == course.Id);

            if (basketItem == null)
            {
                WishlistItem wishlistData = new WishlistItem
                {

                    Course = course,
                    AppUser = user,
                };

                _context.Wishlists.Add(wishlistData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DeleteWishlist(int id)
        {
            Course course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return NotFound();

            WishlistItem existedWishlist = await _context.Wishlists.FirstOrDefaultAsync(b => b.CourseId == course.Id);

            if (existedWishlist != null)
            {
                _context.Wishlists.Remove(existedWishlist);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Wishlist");


        }
    }
}
