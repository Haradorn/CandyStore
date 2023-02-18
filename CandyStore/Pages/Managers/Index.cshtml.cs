using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CandyStore.Data;
using CandyStore.Models;
using ContosoUniversity;

namespace CandyStore.Pages.Managers
{
    public class IndexModel : PageModel
    {
        private readonly CandyStore.Data.CandyContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(CandyContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public ManagersPaginatedList<Manager> Managers { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Manager> managersIQ = from m in _context.Managers
                                             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                managersIQ = managersIQ.Where(m => m.LastName.Contains(searchString)
                            || m.FirstMidName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    managersIQ = managersIQ.OrderByDescending(m => m.LastName);
                    break;
                case "Date":
                    managersIQ = managersIQ.OrderBy(m => m.DateBirth);
                    break;
                case "date_desc":
                    managersIQ = managersIQ.OrderByDescending(m => m.DateBirth);
                    break;
                default:
                    managersIQ = managersIQ.OrderBy(m => m.LastName);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Managers = await ManagersPaginatedList<Manager>.CreateAsync(
                managersIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
