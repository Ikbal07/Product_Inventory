using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Product_Inventory.Business;
using Product_Inventory.Models;

namespace Product_Inventory.Pages.ProductRetailerRegistrations
{

    //Product retailer registration 
    public class CreateModel : PageModel
    {
        //Database context 
        private readonly Product_Inventory.Models.Product_InventoryDatabaseContext _context;

        public CreateModel(Product_Inventory.Models.Product_InventoryDatabaseContext context)
        {
            _context = context;
        }


        //Gets the registration form.
        public IActionResult OnGet()
        {
        ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "ProductDisplayName");
        ViewData["RetailerId"] = new SelectList(_context.Set<Retailer>(), "Id", "RetailerDisplayName");
        ViewData["DeliveryStatus"] = new SelectList(Enum.GetValues(typeof(DeliveryStatus)));
            return Page();
        }

        //Keeps product registration.
        [BindProperty]
        public ProductRetailerRegistration ProductRetailerRegistration { get; set; }

        //Adds a product registration mapping to databse.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProductRetailerRegistration.Add(ProductRetailerRegistration);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}