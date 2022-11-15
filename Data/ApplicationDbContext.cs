using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using movietheatre.Models;

namespace movietheatre.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<movietheatre.Models.Cart> Cart { get; set; }
        public DbSet<movietheatre.Models.Product> Product { get; set; }
        public DbSet<movietheatre.Models.Customer> Customer { get; set; }
        public DbSet<movietheatre.Models.OrderDetails> OrderDetails { get; set; }
        public DbSet<movietheatre.Models.OrderHeader> OrderHeader { get; set; }
    }
}
