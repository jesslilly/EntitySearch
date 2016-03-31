using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace EntitySearch.Demo.Models
{
    class Warehouse
    {
        public int WarehouseId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(40)]
        public string Code { get; set; }

        [StringLength(100)]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }
        [StringLength(100)]
        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [StringLength(100)]
        public string City { get; set; }
        [StringLength(100)]
        public string State { get; set; }
        [StringLength(20)]
        public string Zip { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

    }
}
