﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using movietheatre.Data;
using movietheatre.Models;

namespace movietheatre.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly movietheatre.Data.ApplicationDbContext _context;

        public IndexModel(movietheatre.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }
        
        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
        }
    }
}
