using SmartBeauty.Models;
using SmartBeauty.Models.SchoolViewModels;  // Add VM
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBeauty.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly SmartBeauty.Data.ApplicationDbContext _context;

        public IndexModel(SmartBeauty.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ServiceIndexData Service { get; set; }
        public int ServiceID { get; set; }
        public int SalonID { get; set; }


        public async Task OnGetAsync(int? id, int? salonID)

        {
            Service = new ServiceIndexData();
            Service.Services = await _context.Services
                  .Include(i => i.ServicePrices)
                  .Include(i => i.SalonServices)
                    .ThenInclude(i => i.Salons)
                        .ThenInclude(i => i.Appointments)
                .Include(i => i.SalonServices)
                    .ThenInclude(i => i.Salons)
                        .ThenInclude(i => i.Appointments)
                            .ThenInclude(i => i.Client)
                  .AsNoTracking()
                  .OrderBy(i => i.ServiceName)
                  .ToListAsync();

            if (id != null)
            {
                ServiceID = id.Value;
                Service service = Service.Services.Where(
          i => i.ServiceID == id.Value).Single();
                Service.Salons = service.SalonServices.Select(s => s.Salons); ;
            }

            if (salonID != null)
            {
                salonID = salonID.Value;
                Service.Appointments = Service.Salons.Where(
                    x => x.SalonID == salonID).Single().Appointments;
            }
        }
    }
}