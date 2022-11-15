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

namespace movietheatre.Pages.Details
{
    public class CreateModel : PageModel
    {
        private readonly movietheatre.Data.ApplicationDbContext _context;

        public CreateModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["OrderHeaderId"] = new SelectList(_context.OrderHeader, "ID", "ID");
        ViewData["productsID"] = new SelectList(_context.Product, "ID", "name");
            return Page();
        }

        [BindProperty]
        public OrderDetails OrderDetails { get; set; }

        [BindProperty]
        public IList<Cart> Cart { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Cart = await _context.Cart
               .Include(c => c.customer)
               .Include(c => c.product).ToListAsync();

            foreach (var item in Cart)
            {
                OrderDetails _orderDetails = new OrderDetails();

          //      _orderDetails.OrderHeader = OrderHeader;
            //    _orderDetails.OrderHeaderId = orderHeader.ID;
                _orderDetails.productsID = item.productID;
                _orderDetails.Products = item.product;
                _orderDetails.description = item.product.description;


                _context.OrderDetails.Add(_orderDetails);
                _context.Cart.Remove(item);

            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrderDetails.Add(OrderDetails);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
