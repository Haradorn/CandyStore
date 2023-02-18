using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandyStore.Data;
using CandyStore.Models;
using System.Collections.Generic;

namespace CandyStore.Pages.Sales
{
    public class IndexModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public IndexModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

        public IList<Sale> Sales { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sales != null)
            {
                Sales = await _context.Sales
                .Include(s => s.Buyer)
                .Include(s => s.Manager)
                .Include(s => s.Production)
                .AsNoTracking()
                .ToListAsync();
            }
        }
    }
}