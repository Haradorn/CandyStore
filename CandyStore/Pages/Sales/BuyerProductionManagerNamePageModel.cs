using CandyStore.Data;
using CandyStore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CandyStore.Pages.Sales
{
    public class BuyerProductionManagerNamePageModel : PageModel
    {
        public SelectList BuyerNameSL { get; set; }
        public SelectList ManagerNameSL { get; set; }
        public SelectList ProductionNameSL { get; set; }

        public void PopulateBuyersDropDownList(CandyContext _context,
            object selectedBuyer = null)
        {
            var buyersQuery = from b in _context.Buyers
                              orderby b.Name
                              select b;

            BuyerNameSL = new SelectList(buyersQuery.AsNoTracking(),
                nameof(Buyer.BuyerID),
                nameof(Buyer.Name),
                selectedBuyer);
        }
        public void PopulateManagersDropDownList(CandyContext _context,
            object selectedManager = null)
        {
            var managersQuery = from m in _context.Managers
                              orderby m.LastName
                              select m;

            ManagerNameSL = new SelectList(managersQuery.AsNoTracking(),
                nameof(Manager.ManagerID),
                nameof(Manager.FullName),
                selectedManager);
        }
        public void PopulateProductionsDropDownList(CandyContext _context,
            object selectedProduction = null)
        {
            var productionsQuery = from p in _context.Productions
                                orderby p.Name
                                select p;

            ProductionNameSL = new SelectList(productionsQuery.AsNoTracking(),
                nameof(Production.ProductionID),
                nameof(Production.Name),
                selectedProduction);
        }
    }
}
