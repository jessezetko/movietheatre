using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using movietheatre.Data;
using movietheatre.Models;

namespace movietheatre.Pages.OrderHeaders
{
    public class DetailsModel : PageModel
    {
        private readonly movietheatre.Data.ApplicationDbContext _context;

        public DetailsModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public OrderHeader OrderHeader { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderHeader = await _context.OrderHeader
                .Include(o => o.customer).FirstOrDefaultAsync(m => m.ID == id);

            if (OrderHeader == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
