using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using movietheatre.Models;
using Microsoft.EntityFrameworkCore;

namespace movietheatre.Pages.admin
{
    [Authorize]
      public class IndexModel : PageModel
      {
        private readonly movietheatre.Data.ApplicationDbContext _context;

        [BindProperty(SupportsGet = true)]
        public string fname { get; set; }
        public string lname { get; set; }
        public DateTime? orderDate { get; set; }

        public IndexModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<OrderHeader> OrderHeader { get; set; }
        public IList<Customer> Customer { get; set; }
        public IList<Product> Product { get; set; }

        public async Task<IActionResult> OnGetAsync(string fname, string lname, DateTime? orderDate)
        {

            if(User.Identity.Name != "admin@admin.com")
            {
                return RedirectToPage("../Index");
            }

            var users = from u in _context.OrderHeader
                        select u;

            if (!string.IsNullOrEmpty(fname))
            {
                users = users.Where(s => s.customer.fname.Contains(fname));
            }
            if (!string.IsNullOrEmpty(lname))
            {
                users = users.Where(s => s.customer.lname.Contains(lname));
            }
            if (orderDate.HasValue)
            {
                DateTime dateval = (DateTime) orderDate;
                users = users.Where(s => s.date.Date.Equals(dateval.Date));
            }
            Product = await _context.Product.ToListAsync();
            Customer = await _context.Customer.ToListAsync();
            OrderHeader = await users
                .Include(o => o.customer)
                .Include(o => o.orderDetails).ToListAsync();
            return Page();

        }


    }
}
