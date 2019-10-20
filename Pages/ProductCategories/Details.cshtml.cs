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
    //Gets the details of a category 
    public class DetailsModel : PageModel
    {
        //Database context 
        private readonly Product_Inventory.Models.Product_InventoryDatabaseContext _context;

        public DetailsModel(Product_Inventory.Models.Product_InventoryDatabaseContext context)
        {
            _context = context;
        }

        //Holds the category info.
        public ProductCategory ProductCategory { get; set; }

        //Gets the category information using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductCategory =  _context.ProductCategory.FirstOrDefault(m => m.Id == id);

            if (ProductCategory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
