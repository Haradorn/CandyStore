using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandyStore.Data;
using CandyStore.Models;

namespace CandyStore.Pages.Productions
{
    public class IndexModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public IndexModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

        public IList<Production> Production { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Productions != null)
            {
                Production = await _context.Productions
                .Include(p => p.ProductType).ToListAsync();
            }
        }
    }
}
