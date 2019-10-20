using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product_Inventory.Business;

namespace Product_Inventory.Models
{
    //Connects to database and sync the business layer classes with database.
    public class Product_InventoryDatabaseContext : DbContext
    {
        public Product_InventoryDatabaseContext (DbContextOptions<Product_InventoryDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Product_Inventory.Business.ProductCategory> ProductCategory { get; set; }

        public DbSet<Product_Inventory.Business.ProductRetailerRegistration> ProductRetailerRegistration { get; set; }

        public DbSet<Product_Inventory.Business.Product> Product { get; set; }

        public DbSet<Product_Inventory.Business.Retailer> Retailer { get; set; }
    }
}
