using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandyStore.Data;
using CandyStore.Models;

namespace CandyStore.Pages.Cities
{
    public class IndexModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;

        public IndexModel(CandyStore.Data.CandyContext context)
        {
            _context = context;
        }

        public IList<City> City { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cities != null)
            {
                City = await _context.Cities.ToListAsync();
            }
        }
    }
}
