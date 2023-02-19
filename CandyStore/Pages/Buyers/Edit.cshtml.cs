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

namespace CandyStore.Pages.Buyers
{
    public class EditModel : CityNamePageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public EditModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Buyer Buyer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Buyers == null)
            {
                return NotFound();
            }

            Buyer =  await _context.Buyers.Include(c => c.City).FirstOrDefaultAsync(m => m.BuyerID == id);

            if (Buyer == null)
            {
                return NotFound();
            }


            PopulateCityDropDownList(_context, Buyer.CityID);
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyerToUpdate = await _context.Buyers.FindAsync(id);

            if (buyerToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Buyer>(
                 buyerToUpdate,
                 "buyer",
                 b => b.Name, b => b.Adress, b => b.CityID))
                   
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateCityDropDownList(_context, buyerToUpdate.CityID);
            return Page();
        }
    }
}
