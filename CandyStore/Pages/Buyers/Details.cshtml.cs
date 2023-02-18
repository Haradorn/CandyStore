using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandyStore.Data;
using CandyStore.Models;

namespace CandyStore.Pages.Buyers
{
    public class DetailsModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public DetailsModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

      public Buyer Buyer { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            Buyer = await _context.Buyers
            .Include(c => c.City)
            .Include(s => s.Sales)
                .ThenInclude(s => s.Production)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.BuyerID == id);

            if (Buyer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}