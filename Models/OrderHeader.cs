using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movietheatre.Models
{
    public class OrderHeader
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        public int customerID { get; set; }
        public Customer customer { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        [DataType(DataType.CreditCard)]
        [Range(16, 16, ErrorMessage = "Card number must be 16 digits")]
        public int cardnumber { get; set; }

        public int orderDetailsID { get; set; }
        public List<OrderDetails> orderDetails { get; set; }
    }
}
