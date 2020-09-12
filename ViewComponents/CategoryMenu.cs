using DoAn.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.ViewComponents
{
    public class CategoryMenu:ViewComponent
    {
        private readonly MyDbContext _context;
        public CategoryMenu(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Loais.ToListAsync());
        }
    }
}
