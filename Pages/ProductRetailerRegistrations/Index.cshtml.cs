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
    //Gets all  retailer product mapping records
    public class IndexModel : PageModel
    {
        //Database context 
        private readonly Product_Inventory.Models.Product_InventoryDatabaseContext _context;

        public IndexModel(Product_Inventory.Models.Product_InventoryDatabaseContext context)
        {
            _context = context;
        }

        //Retailer product mapping record list
        public IList<ProductRetailerRegistration> ProductRetailerRegistration { get;set; }

        //Gets all mapping records using a lamda query to get the related data
        public void  OnGet()
        {
            ProductRetailerRegistration =  _context.ProductRetailerRegistration
                .Include(p => p.Product)
                .Include(p => p.Retailer).ToList();
        }
    }
}
