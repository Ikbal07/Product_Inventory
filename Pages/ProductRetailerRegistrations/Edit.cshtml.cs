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

namespace Product_Inventory.Pages.ProductRetailerRegistrations
{
    //Update Product retialer mapping 
    public class EditModel : PageModel
    {
        //Database context 
        private readonly Product_Inventory.Models.Product_InventoryDatabaseContext _context;

        public EditModel(Product_Inventory.Models.Product_InventoryDatabaseContext context)
        {
            _context = context;
        }

        //Keeps the product regsitration mapping
        [BindProperty]
        public ProductRetailerRegistration ProductRetailerRegistration { get; set; }

        //Gets the retailer -product mapping record for update. Uses  a lamda query to get the 
        //Related data.
        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductRetailerRegistration =  _context.ProductRetailerRegistration
                .Include(p => p.Product)
                .Include(p => p.Retailer).FirstOrDefault(m => m.Id == id);

            if (ProductRetailerRegistration == null)
            {
                return NotFound();
            }
           ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "ProductDisplayName");
           ViewData["RetailerId"] = new SelectList(_context.Set<Retailer>(), "Id", "RetailerDisplayName");
            ViewData["DeliveryStatus"] = new SelectList(Enum.GetValues(typeof(DeliveryStatus)), ProductRetailerRegistration.DeliveryStatus);
            return Page();
        }

        //Updates the product retailer mapping record.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProductRetailerRegistration).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductRetailerRegistrationExists(ProductRetailerRegistration.Id))
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

        //Product -retialer mapping record check using a lamda query.
        private bool ProductRetailerRegistrationExists(int id)
        {
            return _context.ProductRetailerRegistration.Any(e => e.Id == id);
        }
    }
}
