using SmartBeauty.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SmartBeauty.Pages.Salons
{
    public class CreateModel : CityNamePageModel
    {
        private readonly SmartBeauty.Data.ApplicationDbContext _context;

        public CreateModel(SmartBeauty.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            PopulateCitysDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Salon Salon { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptySalon = new Salon();

            if (await TryUpdateModelAsync<Salon>(
                 emptySalon,
                 "Salon",   // Prefix for form value.
                 s => s.SalonName, s => s.Address, s => s.PhoneNumber, s => s.Email))
            {
                _context.Salon.Add(emptySalon);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateCitysDropDownList(_context, emptySalon.CityID);
            return Page();
        }
    }
}