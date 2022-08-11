using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Service
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public LayoutService(AppDbContext context,UserManager<AppUser>userManager )
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<Setting>> GetDatas()
        {
            List<Setting> settings = await _context.Settings.ToListAsync();
            return settings;
        }

        public async Task<List<Category>> GetCategories()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<List<Course>> GetCourse()
        {
            List<Course> courses = await _context.Courses.ToListAsync();
            return courses;
        }

        public async Task<List<Branch>> GetBranches()
        {
            List<Branch> branches = await _context.Branches.ToListAsync();
            return branches;
        }

        public async Task<List<BasketItem>> GetBasket()
        {
            List<BasketItem> basketItems = await _context.BasketItems.ToListAsync();
            return basketItems;           
        }

    }
}
