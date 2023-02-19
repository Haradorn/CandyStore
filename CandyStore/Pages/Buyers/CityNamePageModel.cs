using CandyStore.Data;
using CandyStore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CandyStore.Pages.Buyers
{
    public class CityNamePageModel : PageModel
    {
        public SelectList CityNameSL { get; set; }
        public void PopulateCityDropDownList(CandyContext _context,
            object selectedCity = null)
        {
            var citiesQuery = from c in _context.Cities
                              orderby c.Name
                              select c;

            CityNameSL = new SelectList(citiesQuery.AsNoTracking(),
                nameof(City.CityID),
                nameof(City.Name),
                selectedCity);
        }
    }
}
