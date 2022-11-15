using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movietheatre.Models
{
    public class OrderDetails
    {
        public int ID { get; set; }

        public int total { get; set; }

        public string description { get; set; }

        public int productsID { get; set; }
        public Product Products { get; set; }


        //nav props
        public int OrderHeaderId { get; set; }
        public OrderHeader OrderHeader { get; set; }

    }
}
