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

namespace movietheatre.Pages.Products
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly movietheatre.Data.ApplicationDbContext _context;

        public CreateModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var x = ViewData["itemID"];
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (User.Identity.Name != "admin@admin.com")
            {
                return RedirectToPage("../Index");
            }

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (User.Identity.Name != "admin@admin.com")
            {
                return RedirectToPage("../Index");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
