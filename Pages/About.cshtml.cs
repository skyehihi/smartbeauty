using SmartBeauty.Models.ClientViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartBeauty.Models;

namespace SmartBeauty.Pages
{
    public class AboutModel : PageModel
    {
        private readonly SmartBeauty.Data.ApplicationDbContext _context;

        public AboutModel(SmartBeauty.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<DateOfBirthGroup>
    Client
        { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<DateOfBirthGroup>
                data =
                from Client in _context.Client
                group Client by Client.DateOfBirth into dateGroup
                select new DateOfBirthGroup()
                {
                    DateOfBirth = dateGroup.Key,
                    ClientCount = dateGroup.Count()
                };

            Client = await data.AsNoTracking().ToListAsync();
        }
    }
}
