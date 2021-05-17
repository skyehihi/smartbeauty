using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartBeauty.Data;
using SmartBeauty.Models;

namespace SmartBeauty.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly SmartBeauty.Data.ApplicationDbContext _context;

        public IndexModel(SmartBeauty.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Client> Client { get; set; }

        public async Task OnGetAsync(string sortOrder,
    string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Client> clientIQ = from s in _context.Client
                                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                clientIQ = clientIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    clientIQ = clientIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    clientIQ = clientIQ.OrderBy(s => s.DateOfBirth);
                    break;
                case "date_desc":
                    clientIQ = clientIQ.OrderByDescending(s => s.DateOfBirth);
                    break;
                default:
                    clientIQ = clientIQ.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 3;
            Client = await PaginatedList<Client>.CreateAsync(
                clientIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }


    }
}
