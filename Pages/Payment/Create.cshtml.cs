using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using movietheatre.Data;
using movietheatre.Models;

namespace movietheatre.Pages.OrderHeaders
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly movietheatre.Data.ApplicationDbContext _context;

        public CreateModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Cart> Cart { get; set; }

        [BindProperty]
        public OrderHeader OrderHeader { get; set; }

 

        public async Task OnGetAsync()
        { 
            Cart = await _context.Cart
                .Include(c => c.customer)
                .Include(c => c.product).ToListAsync();

            var user = from u in _context.Cart
                       select u;

            ILookup<string, int> lookup = user.ToLookup(n => User.Identity.Name, n => n.customerID);

            
            ViewData["customerID"] = new SelectList(_context.Customer, "ID", "fname", lookup);

            initializeorders();

        }

        public void initializeorders()
        {
            var products = new OrderDetails[]{
                new OrderDetails {}
            };
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            _context.OrderHeader.Add(OrderHeader);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
