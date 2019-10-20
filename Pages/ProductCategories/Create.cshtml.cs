using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Product_Inventory.Business;
using Product_Inventory.Models;

namespace Product_Inventory.Pages.ProductCategories
{
    //Adds a product category to databse
    public class CreateModel : PageModel
    {
        //Database context 
        private readonly Product_Inventory.Models.Product_InventoryDatabaseContext _context;

        public CreateModel(Product_Inventory.Models.Product_InventoryDatabaseContext context)
        {
            _context = context;
        }

        //Gets the product category add form.
        public IActionResult OnGet()
        {
            return Page();
        }

        //Holds the category model.
        [BindProperty]
        public ProductCategory ProductCategory { get; set; }

        //Adds the new category.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProductCategory.Add(ProductCategory);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}