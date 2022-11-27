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

namespace movietheatre.Pages.Customers
{
    [Authorize]
    public class CreateModel : PageModel
    {

        private readonly movietheatre.Data.ApplicationDbContext _context;


        [BindProperty]
        public Customer Customer { get; set; }

        public CreateModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
            // checkIfExists();
        }

        /*  public RedirectToPageResult checkIfExists()
          {
              // Eventually add functionality to make suers unable to add more users
          }
        */

        public IActionResult OnGet()
        {

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Customer.email = User.Identity.Name;
            _context.Customer.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
