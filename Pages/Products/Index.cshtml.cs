using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Product_Inventory.Business;
using Product_Inventory.Models;

namespace Product_Inventory.Pages.Products
{
    //Get all the products
    public class IndexModel : PageModel
    {
        //Database context 
        private readonly Product_Inventory.Models.Product_InventoryDatabaseContext _context;

        public IndexModel(Product_Inventory.Models.Product_InventoryDatabaseContext context)
        {
            _context = context;
        }

        //Product list.
        public IList<Product> Product { get;set; }

        //Get all products using  a lamda query
        public void  OnGet()
        {
            Product =  _context.Product
                .Include(p => p.ProductCategory).ToList();
        }
    }
}
