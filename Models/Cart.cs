using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movietheatre.Models
{
    public class Cart
    {
        public int ID { get; set; }

        [Display(Name ="Customer Name:")]
        public int customerID { get; set; }
        public Customer customer { get; set; }

        [Display(Name="Product:")]
        public int productID { get; set; }
        public Product product { get; set; }

        [Required]
        [Range(1, 50, ErrorMessage = "Must be between 1 and 50")]
        public int quantity { get; set; }
    }
}
