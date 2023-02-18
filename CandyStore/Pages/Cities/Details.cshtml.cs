using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandyStore.Data;
using CandyStore.Models;

namespace CandyStore.Pages.Cities
{
    public class DetailsModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public DetailsModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

      public City City { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cities == null)
            {
                return NotFound();
            }

            var city = await _context.Cities.FirstOrDefaultAsync(m => m.CityID == id);
            if (city == null)
            {
                return NotFound();
            }
            else 
            {
                City = city;
            }
            return Page();
        }
    }
}
