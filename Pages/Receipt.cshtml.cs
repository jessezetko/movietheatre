using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using movietheatre.Models;

namespace movietheatre.Pages
{
    public class ReceiptModel : PageModel
    {

        private readonly movietheatre.Data.ApplicationDbContext _context;

        public ReceiptModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int cnum { get; set; }
        [BindProperty]
        public string addy { get; set; }
        [BindProperty]
        public string city { get; set; }
       
        [BindProperty]
        public string state { get; set; }

        [DataType(DataType.Date)]
        [BindProperty]
        public DateTime date { get; set; }

        [BindProperty]
        public OrderHeader orderHeader { get; set; }

        [BindProperty]
        public IList<Cart> Cart { get; set; }

        [BindProperty]
        public List<OrderDetails> orderDetails { get; set; }


        //throws error when adding OrderHeader to database

        public async Task OnGetAsync()
        {
            Cart = await _context.Cart
                .Include(c => c.customer)
                .Include(c => c.product).ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            Cart = await _context.Cart
                .Include(c => c.customer)
                .Include(c => c.product).ToListAsync();

            orderHeader.customerID = Cart[0].customerID;
            orderHeader.customer = Cart[0].customer;
            orderHeader.cardnumber = cnum;
            orderHeader.address = addy;
            orderHeader.city = city;
            orderHeader.state = state;
            orderHeader.date = date;


            

            foreach (var item in Cart)
            {
                OrderDetails _orderDetails = new OrderDetails();

                _orderDetails.OrderHeader = orderHeader;
                _orderDetails.OrderHeaderId = orderHeader.ID;
                _orderDetails.productsID = item.productID;
                _orderDetails.Products = item.product;
                _orderDetails.total = (int)(item.product.price * item.quantity);
                _orderDetails.description = item.product.description;


                orderDetails.Add(_orderDetails);
                _context.Cart.Remove(item);
                _context.OrderDetails.Add(_orderDetails);

            }



            orderHeader.orderDetails = orderDetails;

            if (ModelState.IsValid)
            {
                _context.OrderHeader.Add(orderHeader);
                
                _context.SaveChanges();
            }


            await _context.SaveChangesAsync();

            
            
            return RedirectToPage("Confirmation");

        }

        
        




        
    }
}
