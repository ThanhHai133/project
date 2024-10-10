using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EF_CodeFirst.Models
{
    public class Product
    {
        [Key]
        public long ProductID { get; set; }
        [Display(Name ="Product Name")]
        [Required]
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        [Required]
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        public string AvailabilityStatus { get; set; }
        [Required]
        public Nullable<long> CategoryID { get; set; }
        public Nullable<long> BrandID { get; set; }
        public Nullable<bool> Active { get; set; }
        [Required]

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }

    }
}