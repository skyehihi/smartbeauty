using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartBeauty.Data;
using SmartBeauty.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SmartBeauty.Pages.Salons
{
    public class IndexModel : PageModel
    {
        private readonly SmartBeauty.Data.ApplicationDbContext _context;

        public IndexModel(SmartBeauty.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public PaginatedList<SmartBeauty.Models.Salon> Salon { get; set; }
        public string SalonNameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList SalonName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SalonSalonName { get; set; }

        public async Task OnGetAsync(string currentFilter, string sortOrder, string searchString, int? pageIndex)

        {
            SalonNameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }


            // Use LINQ to get list of genres.
            IQueryable<SmartBeauty.Models.Salon> salonIQ = from s in _context.Salon
                                                                 select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                salonIQ = salonIQ.Where(s => s.SalonName.Contains(searchString)
                                     );
            }

            switch (sortOrder)
            {
                case "name_desc":
                    salonIQ = salonIQ.OrderByDescending(s => s.SalonName);
                    break;
            }

            int pageSize = 3;
            Salon = await PaginatedList<SmartBeauty.Models.Salon>.CreateAsync(
                salonIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }

}
