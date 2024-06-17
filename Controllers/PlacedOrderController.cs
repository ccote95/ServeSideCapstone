using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSideCapstone.Data;
using ServerSideCapstone.Models;
using ServerSideCapstone.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class PlacedOrderController : ControllerBase
{
    private ServerSideCapstoneDbContext _dbContext;

    public PlacedOrderController(ServerSideCapstoneDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost]
    public IActionResult PlaceOrder(int chosenCard, int id, List<ShoppingCart> cart)
    {
        List<ShoppingCart> foundItems = _dbContext.ShoppingCarts
        .Where(sc => sc.UserProfileId == id).ToList();

        if (cart.Count() == 0)
        {
            return BadRequest();
        }

        foreach (ShoppingCart item in cart)
        {
            PlacedOrder placedOrder = new PlacedOrder()
            {
                ShoppingCartId = item.Id,
                UserPaymentDetailsId = chosenCard,
                PlacedOn = DateTime.Now
            };
            _dbContext.PlacedOrders.Add(placedOrder);
        }

        // _dbContext.ShoppingCarts.RemoveRange(0, count);

        foreach (ShoppingCart item in foundItems)
        {

            _dbContext.ShoppingCarts.Remove(item);
        }
        _dbContext.SaveChanges();

        return NoContent();


    }
}