using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using LIBSchool_FinalProjectBackEnd.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public BasketController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

       
        [Authorize]
        public async Task<IActionResult> Index()
        {
            HomeVM model = new HomeVM
            {
                Categories = await _context.Categories.ToListAsync(),
                Courses = await _context.Courses.ToListAsync(),
                Branches = await _context.Branches.ToListAsync(),
                BasketItems = await _context.BasketItems.ToListAsync(),
                CourseEducations = await _context.CourseEducations.ToListAsync(),
                Educations = await _context.Educations.ToListAsync(),
            };

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> AddBasket(int id)
        {
            
            Course course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return NotFound();

            //Education education = await _context.Educations.FirstOrDefaultAsync();

            CourseEducation educationprice = await _context.CourseEducations.FirstOrDefaultAsync(c => c.EducationId == 1   && c.CourseId == course.Id);

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            BasketItem basketItem = await _context.BasketItems.FirstOrDefaultAsync(b => b.AppUserId == user.Id && b.CourseId == course.Id);

            if (basketItem == null)
            {
                BasketItem basketData = new BasketItem
                {
                    Count = 1,
                    Course = course,
                    AppUser = user,
                    Price = educationprice?.Price,
                };
                _context.BasketItems.Add(basketData);
            }
            else
            {
                basketItem.Count++;
            };

            

            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Home");

        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddBasket(BasketItem item,int id)
        {
            if (!ModelState.IsValid) return View();
            BasketItem existedBasket = await _context.BasketItems.FirstOrDefaultAsync(s => s.Id == item.Id);

            if (existedBasket == null) return NotFound();
            if (id != existedBasket.Id) return BadRequest();

            existedBasket.Count = item.Count;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }





        public async Task<IActionResult> DeleteBasket(int id)
        {
            Course course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return NotFound();

            BasketItem existedBasket = await _context.BasketItems.FirstOrDefaultAsync(b => b.CourseId == course.Id);

            if (existedBasket != null)
            {
                _context.BasketItems.Remove(existedBasket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Basket");

           
        }
    }
}
