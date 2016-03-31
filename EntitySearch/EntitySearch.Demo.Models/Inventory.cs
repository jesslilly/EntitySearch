using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySearch.Demo.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        public int ProductId { get; set; }
        
        public Product Product { get; set; }
        
        public decimal Quantity { get; set; }
        
        public int WarehouseId { get; set; }
        
        public Warehouse Warehouse { get; set; }
    }
}
