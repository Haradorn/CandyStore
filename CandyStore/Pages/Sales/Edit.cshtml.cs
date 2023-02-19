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

namespace CandyStore.Pages.Sales
{
    public class EditModel : BuyerProductionManagerNamePageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public EditModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sale Sale { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sale = await _context.Sales
                .Include(s => s.Buyer).Include(s => s.Production).Include(s => s.Manager).FirstOrDefaultAsync(s => s.SaleID == id);

            if (Sale == null)
            {
                return NotFound();
            }

            PopulateBuyersDropDownList(_context, Sale.BuyerID);
            PopulateManagersDropDownList(_context, Sale.ManagerID);
            PopulateProductionsDropDownList(_context, Sale.ProductionID);

            return Page();



            // if (id == null || _context.Sales == null)
            // {
            //     return NotFound();
            // }

            // var sale =  await _context.Sales.FirstOrDefaultAsync(m => m.SaleID == id);
            // if (sale == null)
            // {
            //     return NotFound();
            // }
            // Sale = sale;
            //ViewData["BuyerID"] = new SelectList(_context.Buyers, "BuyerID", "BuyerID");
            //ViewData["ManagerID"] = new SelectList(_context.Managers, "ManagerID", "FirstMidName");
            //ViewData["ProductionID"] = new SelectList(_context.Productions, "ProductionID", "ProductionID");
            // return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var saleToUpdate = await _context.Sales.FindAsync(id);

            if (saleToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Sale>(
                saleToUpdate,
                "sale",
                s => s.BuyerID, s => s.ManagerID, s => s.ProductionID, s => s.SaleDate, s => s.Price))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateBuyersDropDownList(_context, saleToUpdate.BuyerID);
            PopulateManagersDropDownList(_context, saleToUpdate.ManagerID);
            PopulateProductionsDropDownList(_context, saleToUpdate.ProductionID);

            return Page();

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(Sale).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!SaleExists(Sale.SaleID))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return RedirectToPage("./Index");
        }

        private bool SaleExists(int id)
        {
          return _context.Sales.Any(e => e.SaleID == id);
        }
    }
}
