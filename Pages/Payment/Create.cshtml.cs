using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using movietheatre.Data;
using movietheatre.Models;

namespace movietheatre.Pages.OrderHeaders
{
    public class CreateModel : PageModel
    {
        private readonly movietheatre.Data.ApplicationDbContext _context;

        public CreateModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Cart> Cart { get; set; }

        [BindProperty]
        public OrderHeader OrderHeader { get; set; }

        public IActionResult OnGet(Cart cart)
        {
            ViewData["customerID"] = new SelectList(_context.Customer, "ID", "fname");
     


            return Page();
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
