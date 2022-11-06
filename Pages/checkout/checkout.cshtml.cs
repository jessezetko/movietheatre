using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using movietheatre.Models;
using movietheatre.Data;

namespace movietheatre.Pages.checkout
{
    public class checkoutModel : PageModel
    {

        private readonly movietheatre.Data.ApplicationDbContext _context;

        public checkoutModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Cart> Cart { get; set; }
        public IList<OrderDetails> OrderDetails { get; set; }
        public OrderHeader OrderHeader { get; set; }

        public async Task OnGetAsync()
        {
            Cart = await _context.Cart
                .Include(c => c.customer)
                .Include(c => c.product).ToListAsync();
        }
    }
}
