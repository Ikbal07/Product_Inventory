using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Product_Inventory.Business;
using Product_Inventory.Models;

namespace Product_Inventory.Pages.ProductCategories
{
    //Gets all categories.
    public class IndexModel : PageModel
    {
        //Database context 
        private readonly Product_Inventory.Models.Product_InventoryDatabaseContext _context;

        public IndexModel(Product_Inventory.Models.Product_InventoryDatabaseContext context)
        {
            _context = context;
        }

        //Category list
        public IList<ProductCategory> ProductCategory { get;set; }

        //Gets all categories using a lamda query.
        public  void  OnGet()
        {
            ProductCategory = (from category in _context.ProductCategory select category).ToList();
        }
    }
}
