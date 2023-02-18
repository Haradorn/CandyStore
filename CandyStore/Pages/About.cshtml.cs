using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyStore.Models;
using CandyStore.Data;
using CandyStore.Pages.Managers.CandyViewModels;

namespace CandyStore.Pages
{
    public class AboutModel : PageModel
    {
        private readonly CandyContext _context;

        public AboutModel(CandyContext context)
        {
            _context = context;
        }

        public IList<CategoryDateGroup> Managers { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<CategoryDateGroup> data =
                from manager in _context.Managers
                group manager by manager.Category into categoryGroup
                select new CategoryDateGroup()
                {
                    CategoryName = categoryGroup.Key,
                    ManagerCount = categoryGroup.Count()
                };

            Managers = await data.AsNoTracking().ToListAsync();
        }
    }
}
