using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using movietheatre.Data;
using movietheatre.Models;

namespace movietheatre.Pages.checkout
{
    public class EditModel : PageModel
    {
        private readonly movietheatre.Data.ApplicationDbContext _context;

        public EditModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cart Cart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cart = await _context.Cart
                .Include(c => c.customer)
                .Include(c => c.product).FirstOrDefaultAsync(m => m.ID == id);

            if (Cart == null)
            {
                return NotFound();
            }
           ViewData["customerID"] = new SelectList(_context.Set<Customer>(), "ID", "fname");
           ViewData["productID"] = new SelectList(_context.Set<Product>(), "ID", "name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(Cart.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.ID == id);
        }
    }
}
