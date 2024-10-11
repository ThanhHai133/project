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
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name cannot be blank")]
        [RegularExpression(@"^[A-Za-z 0-9]*$", ErrorMessage = "Cannot use special characters in Product Name")]
        public string ProductName { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Required(ErrorMessage = "Price Name cannot be blank")]
        [Range(0, 100000, ErrorMessage = "Price should be in between 0 to 100000.")]
        public Nullable<decimal> Price { get; set; }
      
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        public string AvailabilityStatus { get; set; }

        [Required(ErrorMessage = "CategoryID Name cannot be blank")]
        public Nullable<long> CategoryID { get; set; }

        [Required(ErrorMessage = "BrandID Name cannot be blank")]
        public Nullable<long> BrandID { get; set; }
        
        public Nullable<bool> Active { get; set; }
  

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }

    }
}