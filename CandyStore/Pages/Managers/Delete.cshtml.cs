using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandyStore.Data;
using CandyStore.Models;

namespace CandyStore.Pages.Managers
{
    public class DeleteModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public DeleteModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Manager Manager { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Managers == null)
            {
                return NotFound();
            }

            var manager = await _context.Managers.FirstOrDefaultAsync(m => m.ManagerID == id);

            if (manager == null)
            {
                return NotFound();
            }
            else 
            {
                Manager = manager;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Managers == null)
            {
                return NotFound();
            }
            var manager = await _context.Managers.FindAsync(id);

            if (manager != null)
            {
                Manager = manager;
                _context.Managers.Remove(Manager);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
