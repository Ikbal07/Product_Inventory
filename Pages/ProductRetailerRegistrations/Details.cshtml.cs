using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Product_Inventory.Business;
using Product_Inventory.Models;

namespace Product_Inventory.Pages.ProductRetailerRegistrations
{
    //Gets the retailer product mapping detail.
    public class DetailsModel : PageModel
    {
        //Database context 
        private readonly Product_Inventory.Models.Product_InventoryDatabaseContext _context;

        public DetailsModel(Product_Inventory.Models.Product_InventoryDatabaseContext context)
        {
            _context = context;
        }

        //Keeps the retaielr product mapping record.
        public ProductRetailerRegistration ProductRetailerRegistration { get; set; }

        //Gets the retailer product registration mapping using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductRetailerRegistration =  _context.ProductRetailerRegistration
                .Include(p => p.Product)
                .Include(p => p.Retailer).FirstOrDefault(m => m.Id == id);

            if (ProductRetailerRegistration == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
