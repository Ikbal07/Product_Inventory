using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Product_Inventory.Business;
using Product_Inventory.Models;

namespace Product_Inventory.Pages.ProductCategories
{
    //Updates a category
    public class EditModel : PageModel
    {
        //Database context 
        private readonly Product_Inventory.Models.Product_InventoryDatabaseContext _context;

        public EditModel(Product_Inventory.Models.Product_InventoryDatabaseContext context)
        {
            _context = context;
        }

        //Holds the category
        [BindProperty]
        public ProductCategory ProductCategory { get; set; }

        //Gets the category to update using a lamda query.
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

        //Updates the category.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProductCategory).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryExists(ProductCategory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        //Category Record check. uses a lamda query.
        private bool ProductCategoryExists(int id)
        {
            return _context.ProductCategory.Any(e => e.Id == id);
        }
    }
}
