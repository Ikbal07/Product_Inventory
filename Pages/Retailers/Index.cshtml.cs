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
    //Get all retailers .
    public class IndexModel : PageModel
    {
        //Database context 
        private readonly Product_Inventory.Models.Product_InventoryDatabaseContext _context;

        public IndexModel(Product_Inventory.Models.Product_InventoryDatabaseContext context)
        {
            _context = context;
        }

        //Retailer list
        public IList<Retailer> Retailer { get;set; }

        //Gets all retailers using a linq query.
        public void  OnGet()
        {
            Retailer = (from retailer in _context.Retailer select retailer).ToList();
        }
    }
}
