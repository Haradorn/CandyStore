using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandyStore.Data;
using CandyStore.Models;

namespace CandyStore.Pages.Productions
{
    public class CreateModel : ProductTypeNamePageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public CreateModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateProductTypeDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Production Production { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {

            var emptyProductuion = new Production();

            if (await TryUpdateModelAsync<Production>(
                emptyProductuion,
                "production",
                p => p.ProductionID, p => p.Name, p => p.ProductTypeID))
            {
                _context.Productions.Add(emptyProductuion);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateProductTypeDropDownList(_context, emptyProductuion.ProductTypeID);
            return Page();
        }
    }
}
