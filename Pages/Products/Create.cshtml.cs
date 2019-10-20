using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Product_Inventory.Business;
using Product_Inventory.Models;

namespace Product_Inventory.Pages.Products
{
    //Regsiters a new product
    public class CreateModel : PageModel
    {
        //Database context 
        private readonly Product_Inventory.Models.Product_InventoryDatabaseContext _context;

        public CreateModel(Product_Inventory.Models.Product_InventoryDatabaseContext context)
        {
            _context = context;
        }

        //Gets the registration form .
        public IActionResult OnGet()
        {
        ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "Id", "CategoryDisplayName");
            return Page();
        }

        //Keeps the product data.
        [BindProperty]
        public Product Product { get; set; }

        //Adds the product to databse.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Product.Add(Product);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}