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
    public class EditModel : ProductTypeNamePageModel
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

            Production =  await _context.Productions.Include(p => p.ProductType).FirstOrDefaultAsync(t => t.ProductionID == id);
            if (Production == null)
            {
                return NotFound();
            }
            PopulateProductTypeDropDownList(_context, Production.ProductTypeID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productToUpdate = await _context.Productions.FindAsync(id);

            if (productToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Production>(
                 productToUpdate,
                 "production",
                 p => p.Name, p => p.ProductTypeID))

            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateProductTypeDropDownList(_context, productToUpdate.ProductTypeID);
            return Page();
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Attach(Production).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductionExists(Production.ProductionID))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return RedirectToPage("./Index");
        //}

        //private bool ProductionExists(int id)
        //{
        //  return _context.Productions.Any(e => e.ProductionID == id);
        //}
    }
}
