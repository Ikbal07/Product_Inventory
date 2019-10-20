using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Product_Inventory.Business;
using Product_Inventory.Models;

namespace Product_Inventory.Pages.Retailers
{
    //Creates a retailer
    public class CreateModel : PageModel
    {
        //Database context 
        private readonly Product_Inventory.Models.Product_InventoryDatabaseContext _context;

        public CreateModel(Product_Inventory.Models.Product_InventoryDatabaseContext context)
        {
            _context = context;
        }

        //Retailer create form.
        public IActionResult OnGet()
        {
            return Page();
        }

        //Keeps the retailer details.
        [BindProperty]
        public Retailer Retailer { get; set; }

        //Adds a retailer to databse.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Retailer.Add(Retailer);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}