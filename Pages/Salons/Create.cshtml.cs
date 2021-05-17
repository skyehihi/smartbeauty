using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBeauty.Data;
using SmartBeauty.Models;

namespace SmartBeauty.Pages.Salons
{
    public class CreateModel : PageModel
    {
        private readonly SmartBeauty.Data.ApplicationDbContext _context;

        public CreateModel(SmartBeauty.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SmartBeauty.Models.Salon Salon { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptySalon = new SmartBeauty.Models.Salon();

            if (await TryUpdateModelAsync<SmartBeauty.Models.Salon>(
                emptySalon,
                "salon",// Prefix for form value.
                s => s.SalonName, s => s.Email, s => s.Address, s => s.PhoneNumber))
            {
                _context.Salon.Add(emptySalon);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return null;

        }
    }
}