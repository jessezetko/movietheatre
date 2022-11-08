using movietheatre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace movietheatre.Data
{
    public class DbInitializer
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;

        }

        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Product.Any() && context.Customer.Any())
            {
                return; // db has been seeded
            }
            if (context.Product.Any() != true)
            {
                var products = new Product[]
                {
                new Product{ name="Popcorn", description="popped corn topped with butter.", price=7.00},
                new Product {name="Ticket", description="Ticket valid for any one movie screening.", price=12.00},
                new Product {name="Fountain Drink", description="One 32 oz fountain beverage.", price=5.00},
                new Product {name="Water", description="One bottled water.", price=3.00},
                new Product {name="Slushie", description="Slushed ice flavored with raspberry, blueberry, or mixed.", price=6.00},
                new Product {name="Candy", description="One boxed candy.", price=4.00},
                new Product {name="Nachos", description="Tortilla chips topped with salsa or nacho cheese.", price=8.00},
                new Product {name="Pretzel", description="Baked soft bread pretzels topped with salt or served plain. Comes with nacho dip.", price=8.00},
                new Product {name="Hot Dog", description="Roasted hot dog served with optional condiments.", price=5.00}
                };
                context.Product.AddRange(products);
            }
            if (context.Customer.Any() != true)
            {
                
            }


            
            context.SaveChanges();
        }
    }
}
