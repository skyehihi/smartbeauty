using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBeauty.Data;
using SmartBeauty.Models;

namespace SmartBeauty.Pages.Clients
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
        public Client Client { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyClient = new Client();

            if (await TryUpdateModelAsync<Client>(
                emptyClient,
                "client",   // Prefix for form value.
                s => s.FirstName, s => s.LastName, s => s.DateOfBirth))
            {
                _context.Client.Add(emptyClient);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return null;
        }

    }
}
