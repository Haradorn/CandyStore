using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandyStore.Data;
using CandyStore.Models;

namespace CandyStore.Pages.Sales
{
    public class DetailsModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public DetailsModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

      public Sale Sale { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            Sale = await _context.Sales
                .Include(p => p.Production)
                .Include(m => m.Manager)
                .Include(b => b.Buyer)
                .ThenInclude(c => c.City)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.SaleID == id);

            if (Sale == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
