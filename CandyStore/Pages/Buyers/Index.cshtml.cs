using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandyStore.Data;
using CandyStore.Models;

namespace CandyStore.Pages.Buyers
{
    public class IndexModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public IndexModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

        public IList<Buyer> Buyers { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Buyers != null)
            {
                Buyers = await _context.Buyers
                .Include(b => b.City)
                .AsNoTracking()
                .ToListAsync();
            }
        }
    }
}
