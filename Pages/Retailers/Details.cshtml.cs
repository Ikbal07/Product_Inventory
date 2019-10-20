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
    //Gets the details of  the retailer.
    public class DetailsModel : PageModel
    {
        //Database context 
        private readonly Product_Inventory.Models.Product_InventoryDatabaseContext _context;

        public DetailsModel(Product_Inventory.Models.Product_InventoryDatabaseContext context)
        {
            _context = context;
        }

        //Retailer information.
        public Retailer Retailer { get; set; }

        //Gets retailer details using lamda query.
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
    }
}
