using LIBSchool_FinalProjectBackEnd.DAL;
using LIBSchool_FinalProjectBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LIBSchool_FinalProjectBackEnd.Service
{
    public class LayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context )
        {
            _context = context;
        }

        public async Task<List<Setting>> GetDatas()
        {
            List<Setting> settings = await _context.Settings.ToListAsync();
            return settings;
        }
    }
}
