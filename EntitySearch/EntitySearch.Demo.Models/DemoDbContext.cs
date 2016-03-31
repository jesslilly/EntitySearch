using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySearch.Demo.Models
{
    public class DemoDbContext : DbContext
    {
        // Your context has been configured to use a 'DemoDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EntitySearch.Demo.Models.DemoDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DemoDbContext' 
        // connection string in the application configuration file.

        // TODO: have connection string in config file?  
        //public DemoDbContext()
        //    : base("name=DemoDbContext")
        //{
        //}

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Demo");

            modelBuilder.Entity<Inventory>().Property(x => x.Quantity).HasPrecision(9, 2);
            modelBuilder.Entity<Order>().Property(x => x.Quantity).HasPrecision(9, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
