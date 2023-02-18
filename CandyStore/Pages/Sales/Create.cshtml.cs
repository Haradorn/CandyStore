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
    public class CreateModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public CreateModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BuyerID"] = new SelectList(_context.Buyers, "BuyerID", "BuyerID");
        ViewData["ManagerID"] = new SelectList(_context.Managers, "ManagerID", "FirstMidName");
        ViewData["ProductionID"] = new SelectList(_context.Productions, "ProductionID", "ProductionID");
            return Page();
        }

        [BindProperty]
        public Sale Sale { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sales.Add(Sale);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
