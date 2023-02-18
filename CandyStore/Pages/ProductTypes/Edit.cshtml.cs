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

namespace CandyStore.Pages.ProductTypes
{
    public class EditModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public EditModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductType ProductType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProductTypes == null)
            {
                return NotFound();
            }

            var producttype =  await _context.ProductTypes.FirstOrDefaultAsync(m => m.ProductTypeID == id);
            if (producttype == null)
            {
                return NotFound();
            }
            ProductType = producttype;
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

            _context.Attach(ProductType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTypeExists(ProductType.ProductTypeID))
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

        private bool ProductTypeExists(int id)
        {
          return _context.ProductTypes.Any(e => e.ProductTypeID == id);
        }
    }
}
