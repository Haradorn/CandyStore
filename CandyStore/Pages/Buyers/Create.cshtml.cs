using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandyStore.Data;
using CandyStore.Models;

namespace CandyStore.Pages.Buyers
{
    public class CreateModel : CityNamePageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public CreateModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateCityDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Buyer Buyer { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {

            var emptyBuyer = new Buyer();

            if (await TryUpdateModelAsync<Buyer>(
                emptyBuyer,
                "buyer",
                s => s.BuyerID, s => s.CityID, s => s.Name, s => s.Adress))
            {
                _context.Buyers.Add(emptyBuyer);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateCityDropDownList(_context, emptyBuyer.CityID);
            return Page();
        }
    }
}
