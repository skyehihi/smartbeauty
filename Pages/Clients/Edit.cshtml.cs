using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartBeauty.Data;
using SmartBeauty.Models;

namespace SmartBeauty.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly SmartBeauty.Data.ApplicationDbContext _context;

        public EditModel(SmartBeauty.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client = await _context.Client.FindAsync(id);

            if (Client == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var ClientToUpdate = await _context.Client.FindAsync(id);

            if (ClientToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Client>(
                ClientToUpdate,
                "Client",
                s => s.FirstName, s => s.LastName, s => s.DateOfBirth))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.ClientID == id);
        }
    }
}