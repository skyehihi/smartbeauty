using SmartBeauty.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SmartBeauty.Pages.Salons
{
    public class CityNamePageModel : PageModel
    {
        public SelectList CityNameSL { get; set; }

        public void PopulateCitysDropDownList(ApplicationDbContext _context,
            object selectedCity = null)
        {
            var CitysQuery = from d in _context.City
                                   orderby d.CityName // Sort by name.
                                   select d;

            CityNameSL = new SelectList(CitysQuery.AsNoTracking(),
                        "CityID", "LastName", selectedCity);
        }
    }
}