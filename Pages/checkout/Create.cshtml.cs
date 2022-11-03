using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using movietheatre.Data;
using movietheatre.Models;

namespace movietheatre.Pages.checkout
{
    public class CreateModel : PageModel
    {
        private readonly movietheatre.Data.ApplicationDbContext _context;

        public CreateModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int itemid)
        {
            ViewData["customerID"] = new SelectList(_context.Set<Customer>(), "ID", "fname");
            ViewData["productID"] = new SelectList(_context.Set<Product>(), "ID", "name", itemid);
            return Page();
        }

        [BindProperty]
        public Cart Cart { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            var customerid = _context.Customer.FirstOrDefault(x => x.email == User.Identity.Name).ID;
            Cart.customerID = customerid;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cart.Add(Cart);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
