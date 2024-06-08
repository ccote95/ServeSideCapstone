using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSideCapstone.Data;
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
        .Include(l => l.Category)
        .ThenInclude(c => c.ListingCategories)
        .Select(l => new ListingsListDTO()
        {
            Id = l.Id,
            UserProfileId = l.UserProfileId,

            ProductImg = l.ProductImg,
            Categories = l.Category.ListingCategories.Select(lc => new CategoryNoNavDTO()
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
}
