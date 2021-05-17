using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartBeauty.Data;
using SmartBeauty.Models;

namespace SmartBeauty.Pages.Salons
{
    public class DeleteModel : PageModel
    {
        private readonly SmartBeauty.Data.ApplicationDbContext _context;

        public DeleteModel(SmartBeauty.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SmartBeauty.Models.Salon Salon { get; set; }
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Salon = await _context.Salon
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.SalonID == id);

            if (Salon == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Salon
                            .AsNoTracking()
                            .FirstOrDefaultAsync(m => m.SalonID == id);

            if (student == null)
            {
                return NotFound();
            }

            try
            {
                _context.Salon.Remove(student);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }

        }
    }
}