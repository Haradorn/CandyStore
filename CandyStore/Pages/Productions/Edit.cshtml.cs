using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CandyStore.Data;
using CandyStore.Models;

namespace CandyStore.Pages.Productions
{
    public class EditModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public EditModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Production Production { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Productions == null)
            {
                return NotFound();
            }

            var production =  await _context.Productions.FirstOrDefaultAsync(m => m.ProductionID == id);
            if (production == null)
            {
                return NotFound();
            }
            Production = production;
           ViewData["ProductTypeID"] = new SelectList(_context.ProductTypes, "ProductTypeID", "ProductTypeID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Production).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionExists(Production.ProductionID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductionExists(int id)
        {
          return _context.Productions.Any(e => e.ProductionID == id);
        }
    }
}
