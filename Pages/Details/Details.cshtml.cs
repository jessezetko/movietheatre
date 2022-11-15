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
    public class DetailsModel : PageModel
    {
        private readonly movietheatre.Data.ApplicationDbContext _context;

        public DetailsModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public OrderDetails OrderDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderDetails = await _context.OrderDetails
                .Include(o => o.OrderHeader)
                .Include(o => o.Products).FirstOrDefaultAsync(m => m.ID == id);

            if (OrderDetails == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
