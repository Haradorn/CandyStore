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
    public class DeleteModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public DeleteModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Production Production { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Productions == null)
            {
                return NotFound();
            }

            var production = await _context.Productions.FirstOrDefaultAsync(m => m.ProductionID == id);

            if (production == null)
            {
                return NotFound();
            }
            else 
            {
                Production = production;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Productions == null)
            {
                return NotFound();
            }
            var production = await _context.Productions.FindAsync(id);

            if (production != null)
            {
                Production = production;
                _context.Productions.Remove(Production);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
