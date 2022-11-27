using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using movietheatre.Data;
using movietheatre.Models;

namespace movietheatre.Pages.checkout
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly movietheatre.Data.ApplicationDbContext _context;

        public IndexModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Cart> Cart { get;set; }


        public async Task OnGetAsync()
        {
            Cart = await _context.Cart
                .Include(c => c.customer)
                .Include(c => c.product).ToListAsync();
        }

      
    }
}
