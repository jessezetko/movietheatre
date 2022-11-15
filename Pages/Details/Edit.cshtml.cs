﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using movietheatre.Data;
using movietheatre.Models;

namespace movietheatre.Pages.Details
{
    public class EditModel : PageModel
    {
        private readonly movietheatre.Data.ApplicationDbContext _context;

        public EditModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["OrderHeaderId"] = new SelectList(_context.OrderHeader, "ID", "ID");
           ViewData["productsID"] = new SelectList(_context.Product, "ID", "ID");
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

            _context.Attach(OrderDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailsExists(OrderDetails.ID))
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

        private bool OrderDetailsExists(int id)
        {
            return _context.OrderDetails.Any(e => e.ID == id);
        }
    }
}
