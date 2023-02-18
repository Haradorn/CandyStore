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
    public class DeleteModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public DeleteModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Buyer Buyer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Buyers == null)
            {
                return NotFound();
            }

            var buyer = await _context.Buyers.FirstOrDefaultAsync(m => m.BuyerID == id);

            if (buyer == null)
            {
                return NotFound();
            }
            else 
            {
                Buyer = buyer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Buyers == null)
            {
                return NotFound();
            }
            var buyer = await _context.Buyers.FindAsync(id);

            if (buyer != null)
            {
                Buyer = buyer;
                _context.Buyers.Remove(Buyer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
