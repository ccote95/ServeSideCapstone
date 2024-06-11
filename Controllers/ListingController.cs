using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSideCapstone.Data;
using ServerSideCapstone.Models;
using ServerSideCapstone.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class ListingController : ControllerBase
{
    private ServerSideCapstoneDbContext _dbContext;

    public ListingController(ServerSideCapstoneDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        List<ListingsListDTO> listings = _dbContext.Listing
        .Include(l => l.UserProfile)
        .Include(l => l.ListingCategories)
        .ThenInclude(lc => lc.Category)
        .Select(l => new ListingsListDTO()
        {
            Id = l.Id,
            UserProfileId = l.UserProfileId,
            Title = l.Title,
            ProductImg = l.ProductImg,
            ImageBlob = l.ImageBlob,
            Price = l.Price,
            Categories = l.ListingCategories.Select(lc => new CategoryNoNavDTO()
            {
                Id = lc.Category.Id,
                Name = lc.Category.Name
            }).ToList(),
            Content = l.Content,
            CreatedOn = l.CreatedOn,
            UserProfile = new UserProfileForListingsDTO()
            {
                Id = l.UserProfile.Id,
                FirstName = l.UserProfile.FirstName,
                LastName = l.UserProfile.LastName,
                ImgLocation = l.UserProfile.ImgLocation


            }


        }).ToList();

        return Ok(listings);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_dbContext.Listing
        .Include(l => l.UserProfile)
        .Include(l => l.ListingCategories)
            .ThenInclude(lc => lc.Category)
            .Select(l => new ListingsListDTO()
            {
                Id = l.Id,
                UserProfileId = l.UserProfileId,
                Title = l.Title,
                ProductImg = l.ProductImg,
                ImageBlob = l.ImageBlob,
                Price = l.Price,
                Categories = l.ListingCategories.Select(lc => new CategoryNoNavDTO()
                {
                    Id = lc.Category.Id,
                    Name = lc.Category.Name
                }).ToList(),
                Content = l.Content,
                CreatedOn = l.CreatedOn,
                UserProfile = new UserProfileForListingsDTO()
                {
                    Id = l.UserProfile.Id,
                    FirstName = l.UserProfile.FirstName,
                    LastName = l.UserProfile.LastName,
                    ImgLocation = l.UserProfile.ImgLocation


                }
            }).FirstOrDefault(l => l.Id == id));
    }

    [HttpPost]
    // [Authorize]
    public IActionResult CreateListing([FromForm] CreateListingDTO newListing)
    {
        string identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        UserProfile profile = _dbContext.UserProfiles.SingleOrDefault(up =>
            up.IdentityUserId == identityUserId
        );

        Listing listing = new Listing()
        {
            UserProfileId = profile.Id,
            Title = newListing.Title,
            Price = newListing.Price,
            Content = newListing.Content,
            CreatedOn = DateTime.Now,
        };

        _dbContext.Listing.Add(listing);
        _dbContext.SaveChanges();

        foreach (int categoryId in newListing.CategoryIds)
        {
            ListingCategory listingCategory = new ListingCategory { ListingId = listing.Id, CategoryId = categoryId };

            _dbContext.ListingCategory.Add(listingCategory);
        }

        if (newListing.FormFile != null)
        {
            byte[] file;
            using (var memoryStream = new MemoryStream())
            {
                newListing.FormFile.CopyTo(memoryStream);
                file = memoryStream.ToArray();
            }

            listing.ImageBlob = file;
        }

        _dbContext.SaveChanges();

        return Ok();


    }

    [HttpDelete("{id}")]
    // [Authorize]
    public IActionResult DeleteListing(int id)
    {
        Listing foundListing = _dbContext.Listing.SingleOrDefault(l => l.Id == id);

        if (foundListing == null)
        {
            return BadRequest();
        }

        _dbContext.Listing.Remove(foundListing);
        _dbContext.SaveChanges();

        return NoContent();
    }
}
