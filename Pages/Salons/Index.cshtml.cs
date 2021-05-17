using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartBeauty.Data;
using SmartBeauty.Models;

namespace SmartBeauty.Pages.Salons
{
    public class IndexModel : PageModel
    {
        private readonly SmartBeauty.Data.ApplicationDbContext _context;

        public IndexModel(SmartBeauty.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Salon> Salon { get;set; }

        public async Task OnGetAsync()
        {
            Salon = await _context.Salon.ToListAsync();
        }
    }
}
