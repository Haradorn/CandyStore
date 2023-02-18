using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandyStore.Data;
using CandyStore.Models;

namespace CandyStore.Pages.Managers
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
            return Page();
        }

        [BindProperty]
        public Manager Manager { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyManager = new Manager();

            if (await TryUpdateModelAsync<Manager>(
                emptyManager,
                "manager",
                m => m.FirstMidName, m => m.LastName, m => m.Category, m => m.DateBirth))
            {
                _context.Managers.Add(emptyManager);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
