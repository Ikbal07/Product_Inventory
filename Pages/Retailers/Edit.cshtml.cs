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

namespace Product_Inventory.Pages.Retailers
{
    //Updates the retailer.
    public class EditModel : PageModel
    {
        //Database context 
        private readonly Product_Inventory.Models.Product_InventoryDatabaseContext _context;

        public EditModel(Product_Inventory.Models.Product_InventoryDatabaseContext context)
        {
            _context = context;
        }

        //Retailer info.
        [BindProperty]
        public Retailer Retailer { get; set; }

        //Gets the retailer information using lamda .
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Retailer = _context.Retailer.FirstOrDefault(m => m.Id == id);

            if (Retailer == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Updates the retailer.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Retailer).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RetailerExists(Retailer.Id))
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

        //Retailer record check using lamda query.
        private bool RetailerExists(int id)
        {
            return _context.Retailer.Any(e => e.Id == id);
        }
    }
}
