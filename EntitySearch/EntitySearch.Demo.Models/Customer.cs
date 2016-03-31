using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySearch.Demo.Models
{
    class Customer
    {
        public int CustomerId { get; set; }
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(100)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
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
