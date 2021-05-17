using SmartBeauty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SmartBeauty.Pages.Salons
{
    public class EditModel : CityNamePageModel
    {
        private readonly SmartBeauty.Data.ApplicationDbContext _context;

        public EditModel(SmartBeauty.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Salon Salon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Salon = await _context.Salon
                .Include(c => c.City).FirstOrDefaultAsync(m => m.SalonID == id);

            if (Salon == null)
            {
                return NotFound();
            }

            // Select current CityID.
            PopulateCitysDropDownList(_context, Salon.CityID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var SalonToUpdate = await _context.Salon.FindAsync(id);

            if (await TryUpdateModelAsync<Salon>(
                 SalonToUpdate,
                 "Salon",   // Prefix for form value.
                   c => c.SalonName, c => c.CityID, c => c.PhoneNumber))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select CityID if TryUpdateModelAsync fails.
            PopulateCitysDropDownList(_context, SalonToUpdate.CityID);
            return Page();
        }
    }
}