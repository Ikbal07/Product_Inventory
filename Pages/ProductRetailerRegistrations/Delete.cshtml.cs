using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Product_Inventory.Business;
using Product_Inventory.Models;

namespace Product_Inventory.Pages.ProductRetailerRegistrations
{
    //Deletes the product retailer registration 
    public class DeleteModel : PageModel
    {
        //Database context 
        private readonly Product_Inventory.Models.Product_InventoryDatabaseContext _context;

        public DeleteModel(Product_Inventory.Models.Product_InventoryDatabaseContext context)
        {
            _context = context;
        }

        //Product retailer registration record.
        [BindProperty]
        public ProductRetailerRegistration ProductRetailerRegistration { get; set; }

        //Gets the available record using a lamda query including related data.
        public IActionResult OnGet(int? id)
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
            return Page();
        }

        //Removes the retailer product registraion. Uses a linq query to check availability.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductRetailerRegistration = (from retailerProd in _context.ProductRetailerRegistration
                                          where retailerProd.Id == id
                                          select retailerProd).FirstOrDefault();

            if (ProductRetailerRegistration != null)
            {
                _context.ProductRetailerRegistration.Remove(ProductRetailerRegistration);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
