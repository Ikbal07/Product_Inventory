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
    //Removes the product.
    public class DeleteModel : PageModel
    {
        //Database context 
        private readonly Product_Inventory.Models.Product_InventoryDatabaseContext _context;

        public DeleteModel(Product_Inventory.Models.Product_InventoryDatabaseContext context)
        {
            _context = context;
        }

        //Keeps the product info.
        [BindProperty]
        public Product Product { get; set; }

        //Gets the product to remove uses a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product =  _context.Product
                .Include(p => p.ProductCategory).FirstOrDefault(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Removes the record uses a linq query to get the record.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = (from product in _context.Product

                       where product.Id == id
                       select product).FirstOrDefault();

            if (Product != null)
            {
                _context.Product.Remove(Product);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
