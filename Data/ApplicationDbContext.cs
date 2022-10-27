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
    }
}
