using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using movietheatre.Data;
using movietheatre.Models;

namespace movietheatre.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        private readonly movietheatre.Data.ApplicationDbContext _context;

        public DeleteModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderHeader OrderHeader { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (User.Identity.Name != "admin@admin.com")
            {
                return RedirectToPage("../Index");
            }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderHeader = await _context.OrderHeader.FindAsync(id);

            if (OrderHeader != null)
            {
                _context.OrderHeader.Remove(OrderHeader);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
