using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSideCapstone.Data;
using ServerSideCapstone.Models;
using ServerSideCapstone.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class ShoppingCartController : ControllerBase
{
    private ServerSideCapstoneDbContext _dbContext;

    public ShoppingCartController(ServerSideCapstoneDbContext context)
    {
        _dbContext = context;
    }


    [HttpPost]
    public IActionResult AddToCart(int id, int userId)
    {
        Listing newCartItem = _dbContext.Listing
        .FirstOrDefault(l => l.Id == id);

        ShoppingCart shoppingCart = new ShoppingCart
        {
            UserProfileId = userId,
            ListingId = newCartItem.Id,
            Total = newCartItem.Price
        };

        _dbContext.ShoppingCarts.Add(shoppingCart);
        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpGet("{id}")]
    public IActionResult GetAllById(int id)
    {
        return Ok(_dbContext.ShoppingCarts
        .Include(sc => sc.UserProfile)
        .Include(sc => sc.Listing)
        .ThenInclude(l => l.ListingCategories)
        .Where(sc => sc.UserProfileId == id)
        .Select(sc => new ShoppingCartDTO()
        {
            Id = sc.Id,
            UserProfileId = sc.UserProfileId,
            UserProfile = new UserProfileForShoppingCartDTO
            {
                Id = sc.UserProfile.Id,
                FirstName = sc.UserProfile.FirstName,
                LastName = sc.UserProfile.LastName,
                Address = sc.UserProfile.Address,
                Email = sc.UserProfile.Email
            },
            ListingId = sc.ListingId,
            Listing = new ListingDTO
            {
                Id = sc.ListingId,
                UserProfileId = sc.UserProfileId,
                Title = sc.Listing.Title,
                Price = sc.Listing.Price,
                Content = sc.Listing.Content,
                CreatedOn = sc.Listing.CreatedOn
            },
            Total = sc.Listing.Price


        }).ToList());
    }
}