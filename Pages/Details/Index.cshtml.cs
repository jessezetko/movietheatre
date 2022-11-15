using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using movietheatre.Data;
using movietheatre.Models;

namespace movietheatre.Pages.Details
{
    public class IndexModel : PageModel
    {
        private readonly movietheatre.Data.ApplicationDbContext _context;

        public IndexModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<OrderDetails> OrderDetails { get;set; }

        public async Task OnGetAsync()
        {
            OrderDetails = await _context.OrderDetails
                .Include(o => o.OrderHeader)
                .Include(o => o.Products).ToListAsync();
        }
    }
}
