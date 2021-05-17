using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBeauty.Data;
using SmartBeauty.Models;
using System.Security.Claims;


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
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != "332ea6a5-41b4-4d87-86a2-d2fa39d685ab")
            {
                return Redirect("~/Identity/Account/Login");
            }

            return Page();
        }

        [BindProperty]
        public Salon Salon { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Salon.Add(Salon);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
