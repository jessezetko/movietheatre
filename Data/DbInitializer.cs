using Microsoft.AspNetCore.Identity;
using movietheatre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if (context.Product.Any() || context.Customer.Any())
            {
                return; // db has been seeded
            }
            if (context.Product.Any() != true)
            {
                var products = new Product[]
                {
                new Product{ name="Popcorn", description="popped corn topped with butter.", price=7.00, image = "https://www.waff.com/resizer/YXTv1YuBYMHxRelOox0RVaxWqag=/arc-photo-gray/arc3-prod/public/B6L4RX347ZDWDMFLGUTSKGLNM4.png"},
                new Product {name="Ticket", description="Ticket valid for any one movie screening.", price=12.00, image="https://media.istockphoto.com/id/901315062/photo/messy-ticket-roll.jpg?b=1&s=170667a&w=0&k=20&c=1kT_t9Qfq7wLArwcL8Fm4LPiWj7iqsmGja39PAM3a4w="},
                new Product {name="Fountain Drink", description="One 32 oz fountain beverage.", price=5.00, image="https://www.webstaurantstore.com/images/products/large/464943/1741018.jpg"},
                new Product {name="Water", description="One bottled water.", price=3.00, image="https://www.seriouseats.com/thmb/PkSTTuCnE7aboaVY-RjPr1oI1Ag=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__serious_eats__seriouseats.com__images__2017__06__20170620-water-bottle-vicky-wasik-group1-210a332e1342467b8eea4f804ca935b4.jpg"},
                new Product {name="ICEE", description="Ice flavored with raspberry, blueberry, or mixed.", price=6.00, image="https://cdn.shopify.com/s/files/1/0976/6524/products/iceecherrypalette5.jpg?v=1639296201"},
                new Product {name="Candy", description="One boxed candy.", price=4.00, image="https://m.media-amazon.com/images/I/91jYwM-NGuL.jpg"},
                new Product {name="Nachos", description="Tortilla chips topped with salsa or nacho cheese.", price=8.00, image="https://d.newsweek.com/en/full/1850144/nachos-cheese-top-lime.jpg"},
                new Product {name="Pretzel", description="Baked soft bread pretzels topped with salt or served plain. Comes with nacho dip.", price=8.00, image="https://sallysbakingaddiction.com/wp-content/uploads/2017/04/easy-homemade-soft-pretzels.jpg"},
                new Product {name="Hot Dog", description="Roasted hot dog served with optional condiments.", price=5.00, image="https://www.thedailymeal.com/img/gallery/why-is-a-hot-dog-a-snack-option-at-the-movie-theater/iStock-494317722.jpg"}
                };
                context.Product.AddRange(products);
            }
            if (context.Customer.Any() != true)
            {
                var pHasher = new PasswordHasher<IdentityUser>();
                var user = new IdentityUser { Email = "admin@admin.com", UserName = "admin@admin.com", EmailConfirmed = true, NormalizedUserName = "ADMIN@ADMIN.COM", NormalizedEmail = "ADMIN@ADMIN.COM" };
                user.SecurityStamp = Guid.NewGuid().ToString();
                user.PasswordHash = pHasher.HashPassword(user, "password");
                context.Users.AddRange(user);

                var role = new IdentityRole { Name = "admin", NormalizedName = "ADMIN"};
                context.Roles.Add(role);

                var userRole = new IdentityUserRole<string>();
                userRole.RoleId = role.Id;

                userRole.UserId = user.Id;

                context.UserRoles.Add(userRole);
            }

            context.SaveChanges();
        }

        public void setPasswowrd()
        {

        }

    }
}
