using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using movietheatre.Models;
using Microsoft.EntityFrameworkCore;
using movietheatre.Data;




namespace movietheatre.Pages
{
   
    public class ConfirmationModel : PageModel
    {
        private readonly movietheatre.Data.ApplicationDbContext _context;

        public ConfirmationModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<OrderDetails> OrderDetails { get; set; }


        public async Task OnGetAsync()
        {
            
        }

    }
}
