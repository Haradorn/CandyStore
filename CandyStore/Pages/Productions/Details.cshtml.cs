using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandyStore.Data;
using CandyStore.Models;

namespace CandyStore.Pages.Productions
{
    public class DetailsModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public DetailsModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

      public Production Production { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            Production = await _context.Productions
            .Include(t => t.ProductType)
            .Include(s => s.Sales)
                .ThenInclude(b => b.Buyer)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.ProductionID == id);

            if (Production == null)
            {
                return NotFound();
            }
            return Page();
        }

    }
}
