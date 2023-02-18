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
    public class DetailsModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public DetailsModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

      public Manager Manager { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Managers == null)
            {
                return NotFound();
            }

            Manager = await _context.Managers
                .Include(m => m.Sales)
                .ThenInclude(s => s.Production)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.ManagerID == id);

            if (Manager == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
