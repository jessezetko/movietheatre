using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movietheatre.Models
{
    public class Cart
    {
        public int ID { get; set; }

        public int customerID { get; set; }
        public Customer customer { get; set; }

        public int productID { get; set; }
        public Product product { get; set; }

        public int quantity { get; set; }
    }
}
