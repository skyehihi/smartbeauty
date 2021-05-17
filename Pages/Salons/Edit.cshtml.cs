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

namespace SmartBeauty.Pages.Salons
{
    public class EditModel : PageModel
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

            Salon = await _context.Salon.FirstOrDefaultAsync(m => m.SalonID == id);

            if (Salon == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Salon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalonExists(Salon.SalonID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SalonExists(int id)
        {
            return _context.Salon.Any(e => e.SalonID == id);
        }
    }
}