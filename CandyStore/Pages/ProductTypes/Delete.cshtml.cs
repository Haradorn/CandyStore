using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandyStore.Data;
using CandyStore.Models;

namespace CandyStore.Pages.ProductTypes
{
    public class DeleteModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public DeleteModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ProductType ProductType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProductTypes == null)
            {
                return NotFound();
            }

            var producttype = await _context.ProductTypes.FirstOrDefaultAsync(m => m.ProductTypeID == id);

            if (producttype == null)
            {
                return NotFound();
            }
            else 
            {
                ProductType = producttype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ProductTypes == null)
            {
                return NotFound();
            }
            var producttype = await _context.ProductTypes.FindAsync(id);

            if (producttype != null)
            {
                ProductType = producttype;
                _context.ProductTypes.Remove(ProductType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
