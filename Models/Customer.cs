using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movietheatre.Models
{
    public class Customer
    {
        public int ID { get; set; }

        public string fname { get; set; }

        public string lname { get; set; }

        public string postal { get; set; }

        public string email { get; set; }

        [Display(Name ="Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
    }
}
