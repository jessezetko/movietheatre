using movietheatre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movietheatre.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Product.Any())
            {
                return; // db has been seeded
            }
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
        }
    }
}
