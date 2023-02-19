using CandyStore.Data;
using CandyStore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CandyStore.Pages.Productions
{
    public class ProductTypeNamePageModel : PageModel
    {
        public SelectList ProductTypeNameSL { get; set; }
        public void PopulateProductTypeDropDownList(CandyContext _context,
            object selectedProductType = null)
        {
            var productTypesQuery = from p in _context.ProductTypes
                              orderby p.ProductTypeName
                              select p;

            ProductTypeNameSL = new SelectList(productTypesQuery.AsNoTracking(),
                nameof(ProductType.ProductTypeID),
                nameof(ProductType.ProductTypeName),
                selectedProductType);
        }
    }
}
