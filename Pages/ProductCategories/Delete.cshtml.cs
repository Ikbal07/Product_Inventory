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
    //Removes the selected category from the databse.
    public class DeleteModel : PageModel
    {
        //Database context 
        private readonly Product_Inventory.Models.Product_InventoryDatabaseContext _context;

        public DeleteModel(Product_Inventory.Models.Product_InventoryDatabaseContext context)
        {
            _context = context;
        }

        //Holds the category.
        [BindProperty]
        public ProductCategory ProductCategory { get; set; }

        //Gets the category to delete using a lamda query.
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

        //Deletes the category uses a linq query to get the category.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductCategory = (from category in _context.ProductCategory

                               where category.Id == id
                               select category).FirstOrDefault();

            if (ProductCategory != null)
            {
                _context.ProductCategory.Remove(ProductCategory);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
