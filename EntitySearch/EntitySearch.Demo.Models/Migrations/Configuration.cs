namespace EntitySearch.Demo.Models.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntitySearch.Demo.Models.DemoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntitySearch.Demo.Models.DemoDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.Warehouses.AddOrUpdate(x => x.WarehouseId, new Warehouse[]
            {
                new Warehouse { WarehouseId = 1, Name = "Boston Dist. Center", Address1 = "123 Main St.", Address2 = "", City = "Boston", State = "MA", Country = "USA", Code = "BSC01", Zip = "08081" },
                new Warehouse { WarehouseId = 2, Name = "Boise Dist. Center", Address1 = "9487 Z St.", Address2 = "", City = "Boise", State = "ID", Country = "USA", Code = "BIC02", Zip = "09651" },
                new Warehouse { WarehouseId = 3, Name = "Dallas Dist. Center", Address1 = "9200 Purple St.", Address2 = "", City = "Dallas", State = "TX", Country = "USA", Code = "DTC04", Zip = "63918" },
                new Warehouse { WarehouseId = 4, Name = "Tokyo Dist. Center", Address1 = "85 Hokawa St.", Address2 = "", City = "Tokyo", State = "TK", Country = "Japan", Code = "TKJ05", Zip = "00948743-1" },
            });

            context.Products.AddOrUpdate(x => x.ProductId, new Product[]
            {
                new Product { ProductId = 1, Color = "green", Description = "Green ice", Manufacturer = "EARTH", ModelNumber = "AN0004K", Sku = "054837-049473" },
                new Product { ProductId = 2, Color = "green", Description = "Green eggs", Manufacturer = "DR S.", ModelNumber = "GEGGS", Sku = "059858-94854" },
                new Product { ProductId = 3, Color = "black", Description = "iPhone 6", Manufacturer = "Apple", ModelNumber = "IPHONE6B", Sku = "0685673-048474" },
                new Product { ProductId = 4, Color = "white", Description = "iPhone 6", Manufacturer = "Apple", ModelNumber = "IPHONE6W", Sku = "0685673-048475" },
                new Product { ProductId = 5, Color = "clear", Description = "Empty glass", Manufacturer = "Hananana", ModelNumber = "05985734/A", Sku = "645128-054863" },
                new Product { ProductId = 6, Color = "red", Description = "The best thing in the world", Manufacturer = "Life", ModelNumber = "09876543211234567890", Sku = "01011-0000101" },
                new Product { ProductId = 7, Color = "orange", Description = "Delicous Oranges", Manufacturer = "Con Agra", ModelNumber = "757363629", Sku = "958326" },
                new Product { ProductId = 8, Color = "yellow", Description = "Highlighter pen 6 pack", Manufacturer = "Bic", ModelNumber = "474623525627348", Sku = "95874563-635214" },
            });

            context.Customers.AddOrUpdate(x => x.CustomerId, new Customer[]
            {
                new Customer { CustomerId = 1, FirstName = "James", LastName = "Hanagdue", Address1 = "99999 Smile St.", Address2 = "Appt 123456", City = "Dallas", State = "TX", Zip = "05483", Country = "USA", Phone = "8885550001" },
                new Customer { CustomerId = 2, FirstName = "Lee", LastName = "Manjinyoo", Address1 = "1000 Happy St.", Address2 = "Appt 1", City = "Dallas", State = "TX", Zip = "05483", Country = "USA", Phone = "8885550002" },
                new Customer { CustomerId = 3, FirstName = "Dominique", LastName = "Franciponiapolise", Address1 = "100 Whoa St.", Address2 = "Appt 99", City = "Dallas", State = "TX", Zip = "05483", Country = "USA", Phone = "8885550003" },
            });

            context.Inventories.AddOrUpdate(x => x.InventoryId, new Inventory[]
            {
                new Inventory { InventoryId = 1, ProductId = 1, Quantity = 9, WarehouseId = 1 },
                new Inventory { InventoryId = 2, ProductId = 2, Quantity = 19, WarehouseId = 1 },
                new Inventory { InventoryId = 3, ProductId = 3, Quantity = 29, WarehouseId = 2 },
                new Inventory { InventoryId = 4, ProductId = 4, Quantity = 39, WarehouseId = 1 },
                new Inventory { InventoryId = 5, ProductId = 5, Quantity = 49, WarehouseId = 1 },
                new Inventory { InventoryId = 6, ProductId = 6, Quantity = 59, WarehouseId = 3 },
                new Inventory { InventoryId = 7, ProductId = 7, Quantity = 69, WarehouseId = 1 },
                new Inventory { InventoryId = 8, ProductId = 8, Quantity = 79, WarehouseId = 4 },
                new Inventory { InventoryId = 9, ProductId = 1, Quantity = 89, WarehouseId = 1 },
                new Inventory { InventoryId = 10, ProductId = 2, Quantity = 99, WarehouseId = 4 },
                new Inventory { InventoryId = 11, ProductId = 3, Quantity = 1, WarehouseId = 3 },
                new Inventory { InventoryId = 12, ProductId = 4, Quantity = 2, WarehouseId = 1 },
            });

            context.Orders.AddOrUpdate(x => x.OrderId, new Order[]
            {
                new Order { OrderId = 1, ProductId = 1, Quantity = 1, CustomerId = 1, OrderNumber = "ASDF-1234" },
                new Order { OrderId = 2, ProductId = 2, Quantity = 2, CustomerId = 2, OrderNumber = "ASDF-9999" },
                new Order { OrderId = 3, ProductId = 3, Quantity = 1, CustomerId = 3, OrderNumber = "ASDF-0000" },
                new Order { OrderId = 4, ProductId = 4, Quantity = 55, CustomerId = 1, OrderNumber = "ASDF-2345" },
                new Order { OrderId = 5, ProductId = 5, Quantity = 1, CustomerId = 2, OrderNumber = "ASDF-0974" },
                new Order { OrderId = 6, ProductId = 6, Quantity = 2, CustomerId = 3, OrderNumber = "ASDF-8476" },
                new Order { OrderId = 7, ProductId = 7, Quantity = 1, CustomerId = 1, OrderNumber = "A0000001001" },
                new Order { OrderId = 8, ProductId = 8, Quantity = 100, CustomerId = 2, OrderNumber = "A0000001002" },
                new Order { OrderId = 9, ProductId = 1, Quantity = 1, CustomerId = 1, OrderNumber = "A0000001003" },
                new Order { OrderId = 10, ProductId = 2, Quantity = 10, CustomerId = 3, OrderNumber = "A0000001004" },
            });
        }
    }
}
