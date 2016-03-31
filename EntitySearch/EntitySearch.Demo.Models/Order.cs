using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySearch.Demo.Models
{
    class Order
    {
        public int OrderId { get; set; }

        [StringLength(100)]
        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int ProductId { get; set; }

        // Sorry, but only one Product per order.  LOL
        public Product Product { get; set; }

        public decimal Quantity { get; set; }
    }
}
