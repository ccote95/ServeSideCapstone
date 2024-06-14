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

        ShoppingCart shoppingCart = new ShoppingCart()
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
        .Where(sc => sc.UserProfileId == id).ToList());
    }
}