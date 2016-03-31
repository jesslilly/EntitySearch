using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySearch.Demo.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [StringLength(100)]
        public string Manufacturer { get; set; }

        [StringLength(100)]
        [Display(Name = "Model Number")]
        public string ModelNumber { get; set; }

        [StringLength(100)]
        [Display(Name = "SKU")]
        public string Sku { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Color { get; set; }
    }
}
