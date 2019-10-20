using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Product_Inventory.Business;
using Product_Inventory.Models;

namespace Product_Inventory.Pages.Retailers
{
    //Removes a retailer .
    public class DeleteModel : PageModel
    {
        //Database context 
        private readonly Product_Inventory.Models.Product_InventoryDatabaseContext _context;

        public DeleteModel(Product_Inventory.Models.Product_InventoryDatabaseContext context)
        {
            _context = context;
        }

        //Retialer info.
        [BindProperty]
        public Retailer Retailer { get; set; }

        //Gets retailer delete page uses a lamda to get the record.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Retailer =  _context.Retailer.FirstOrDefault(m => m.Id == id);

            if (Retailer == null)
            {
                return NotFound();
            }
            return Page();
        }


        //Removes a retailer. uses a linq query to get the record
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Retailer = (from retailer in _context.Retailer

                        where retailer.Id == id
                        select retailer).FirstOrDefault();

            if (Retailer != null)
            {
                _context.Retailer.Remove(Retailer);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
