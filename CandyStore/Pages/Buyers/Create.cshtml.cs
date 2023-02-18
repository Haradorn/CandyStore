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
    public class CreateModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public CreateModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CityID"] = new SelectList(_context.Cities, "CityID", "CityID");
            return Page();
        }

        [BindProperty]
        public Buyer Buyer { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Buyers.Add(Buyer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
