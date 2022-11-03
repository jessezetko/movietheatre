using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using movietheatre.Data;
using movietheatre.Models;

namespace movietheatre.Pages.checkout
{
    [Authorize]
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
            var customerid = 0;

            if (_context.Customer.FirstOrDefault(x => x.email == User.Identity.Name) != null)
            {
                customerid = _context.Customer.FirstOrDefault(x => x.email == User.Identity.Name).ID;
                Cart.customerID = customerid;
            }
            else
            {
                // create user if doesn't exist
                var Customers = new Customer[]
                {
                    new Customer {email = User.Identity.Name, dob=DateTime.Now, postal="1111", fname="test" , lname="test2"}
                };

                _context.Customer.AddRange(Customers);

                _context.SaveChanges();

                customerid = _context.Customer.FirstOrDefault(x => x.email == User.Identity.Name).ID;
                Cart.customerID = customerid;
            }

            

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
