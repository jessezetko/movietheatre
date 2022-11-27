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
    [Authorize(Roles="admin")]
      public class IndexModel : PageModel
      {
        private readonly movietheatre.Data.ApplicationDbContext _context;

        public IndexModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<OrderHeader> OrderHeader { get; set; }

        public async Task OnGetAsync()
        {
            OrderHeader = await _context.OrderHeader
                .Include(o => o.customer)
                .Include(o => o.orderDetails).ToListAsync();

        }
    }
}
