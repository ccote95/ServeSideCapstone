using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ServerSideCapstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Design;

namespace ServerSideCapstone.Data;
public class ServerSideCapstoneDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;

    public ServerSideCapstoneDbContext(DbContextOptions<ServerSideCapstoneDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Listing> Listing { get; set; }
    public DbSet<IdentityRole> IdentityRoles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<PaymentDetails> PaymentDetails { get; set; }
    public DbSet<PlacedOrder> PlacedOrders { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public DbSet<ListingCategory> ListingCategory { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure composite key for ListingCategory
        modelBuilder.Entity<ListingCategory>().HasKey(lc => new { lc.ListingId, lc.CategoryId });

        modelBuilder.Entity<ListingCategory>()
            .HasOne(lc => lc.Listing)
            .WithMany(l => l.ListingCategories)
            .HasForeignKey(lc => lc.ListingId);

        modelBuilder.Entity<ListingCategory>()
            .HasOne(lc => lc.Category)
            .WithMany(c => c.ListingCategories)
            .HasForeignKey(lc => lc.CategoryId);

        modelBuilder.Entity<ShoppingCart>()
            .HasOne(sc => sc.UserProfile);









        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "ADMIN"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });

        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Furniture" },
            new Category { Id = 3, Name = "Clothing" },
            new Category { Id = 4, Name = "Books" },
            new Category { Id = 5, Name = "Toys" }

        }
        );

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street",
            ImgLocation = ""
        });

        modelBuilder.Entity<Listing>().HasData(new Listing[]
        {
            new Listing { Id = 1, UserProfileId = 1, ProductImg = "https://m.media-amazon.com/images/I/61DbVExME8L._AC_UF1000,1000_QL80_.jpg", Title = "Ps2 for sale!",Price = 199.99m, Content = "Item for sale 1", CreatedOn = DateTime.Now.AddDays(3) },
            new Listing
            {
                Id = 2,
                UserProfileId = 1,
                Title = "Smartphone for sale",
                Content = "Brand new smartphone.",
                ProductImg = "https://cdn.thewirecutter.com/wp-content/media/2023/10/smartphone-2048px-4861.jpg?auto=webp&quality=75&width=1024",
                Price = 299.99m,
                CreatedOn = DateTime.Now
            },
                new Listing
            {
                Id = 3,
                UserProfileId = 1,
                Title = "Laptop for sale",
                Content = "Gently used laptop in excellent condition.",
                ProductImg = "https://i5.walmartimages.com/seo/HP-Stream-14-Laptop-Intel-Celeron-N4000-4GB-SDRAM-32GB-eMMC-Office-365-1-yr-Brilliant-Black_d579aa66-7e24-4eb2-9686-521be769a755_2.09283250bd5d2a12834c2d4aaca652dd.jpeg",
                Price = 799.99m, // Price set to $799.99
                CreatedOn = DateTime.Now.AddDays(-7) // Created 7 days ago
            },
            new Listing
            {
                Id = 4,
                UserProfileId = 1,
                Title = "Wooden Table",
                Content = "Hand made wooden table",
                ProductImg = "https://i.ebayimg.com/images/g/DasAAOSwZwRj0qTG/s-l1200.webp",
                Price = 399.99m, // Price set to $399.99
                CreatedOn = DateTime.Now.AddDays(-3) // Created 3 days ago
            }

        }
        );

        modelBuilder.Entity<ListingCategory>().HasData(new ListingCategory[]
        {
            new ListingCategory { ListingId = 1, CategoryId = 1 },
            new ListingCategory { ListingId = 2, CategoryId = 1 },
             new ListingCategory { ListingId = 3, CategoryId = 1 },
            new ListingCategory { ListingId = 4, CategoryId = 2 }
        }
        );
    }

}