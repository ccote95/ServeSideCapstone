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

    public DbSet<ListingCategory> ListingCategory { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street",
            ImgLocation = ""
        });

        modelBuilder.Entity<Listing>().HasData(
            new Listing { Id = 1, UserProfileId = 1, ProductImg = "", Content = "Item for sale 1", CreatedOn = DateTime.Now, CategoryId = 1 }

        );



        modelBuilder.Entity<ListingCategory>().HasData(
            new ListingCategory { Id = 1, ListingId = 1, CategoryId = 1 }

        );

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Furniture" },
            new Category { Id = 3, Name = "Clothing" },
            new Category { Id = 4, Name = "Books" },
            new Category { Id = 5, Name = "Toys" }
        );

    }

}