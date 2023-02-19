using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandyStore.Data;
using CandyStore.Models;

namespace CandyStore.Pages.Sales
{
    public class CreateModel : BuyerProductionManagerNamePageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public CreateModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateBuyersDropDownList(_context);
            PopulateManagersDropDownList(_context);
            PopulateProductionsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Sale Sale { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptySale = new Sale();

            if (await TryUpdateModelAsync<Sale>(
                 emptySale,
                 "sale",   // Prefix for form value.
                 s => s.SaleID, s => s.ManagerID, s => s.ProductionID, s => s.BuyerID, s => s.SaleDate, s => s.Price))
            {
                _context.Sales.Add(emptySale);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateBuyersDropDownList(_context, emptySale.BuyerID);
            PopulateManagersDropDownList(_context, emptySale.ManagerID);
            PopulateProductionsDropDownList(_context, emptySale.ProductionID);
            return Page();

            //if (!ModelState.IsValid)
            //  {
            //      return Page();
            //  }

            //  _context.Sales.Add(Sale);
            //  await _context.SaveChangesAsync();

            //  return RedirectToPage("./Index");
        }
    }
}
