namespace EntitySearch.Demo.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Demo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 100),
                        Address1 = c.String(maxLength: 100),
                        Address2 = c.String(maxLength: 100),
                        City = c.String(maxLength: 100),
                        State = c.String(maxLength: 100),
                        Zip = c.String(maxLength: 20),
                        Country = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "Demo.Inventories",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 9, scale: 2),
                        WarehouseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryId)
                .ForeignKey("Demo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("Demo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.WarehouseId);
            
            CreateTable(
                "Demo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Manufacturer = c.String(maxLength: 100),
                        ModelNumber = c.String(maxLength: 100),
                        Sku = c.String(maxLength: 100),
                        Description = c.String(maxLength: 200),
                        Color = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "Demo.Warehouses",
                c => new
                    {
                        WarehouseId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Code = c.String(maxLength: 40),
                        Address1 = c.String(maxLength: 100),
                        Address2 = c.String(maxLength: 100),
                        City = c.String(maxLength: 100),
                        State = c.String(maxLength: 100),
                        Zip = c.String(maxLength: 20),
                        Country = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.WarehouseId);
            
            CreateTable(
                "Demo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderNumber = c.String(maxLength: 100),
                        CustomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 9, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("Demo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("Demo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Demo.Orders", "ProductId", "Demo.Products");
            DropForeignKey("Demo.Orders", "CustomerId", "Demo.Customers");
            DropForeignKey("Demo.Inventories", "WarehouseId", "Demo.Warehouses");
            DropForeignKey("Demo.Inventories", "ProductId", "Demo.Products");
            DropIndex("Demo.Orders", new[] { "ProductId" });
            DropIndex("Demo.Orders", new[] { "CustomerId" });
            DropIndex("Demo.Inventories", new[] { "WarehouseId" });
            DropIndex("Demo.Inventories", new[] { "ProductId" });
            DropTable("Demo.Orders");
            DropTable("Demo.Warehouses");
            DropTable("Demo.Products");
            DropTable("Demo.Inventories");
            DropTable("Demo.Customers");
        }
    }
}
