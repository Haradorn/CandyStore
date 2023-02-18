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

namespace CandyStore.Pages.Managers
{
    public class EditModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public EditModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Manager Manager { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manager = await _context.Managers.FindAsync(id);

            if (Manager == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var managerToUpdate = await _context.Managers.FindAsync(id);

            if (managerToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Manager>(
                managerToUpdate,
                "manager",
                m => m.FirstMidName, m => m.LastName, m => m.Category, m => m.DateBirth))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool ManagerExists(int id)
        {
          return _context.Managers.Any(e => e.ManagerID == id);
        }
    }
}
