using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSideCapstone.Data;
using ServerSideCapstone.Models;
using ServerSideCapstone.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class PaymentDetailsController : ControllerBase
{
    private ServerSideCapstoneDbContext _dbContext;

    public PaymentDetailsController(ServerSideCapstoneDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost]
    public IActionResult AddNewCard(PaymentDetailsDTO newCard)
    {
        PaymentDetails addCard = new PaymentDetails()
        {
            UserProfileId = newCard.UserProfileId,
            CreditCardNumber = newCard.CreditCardNumber,
            CreditCardExpiration = newCard.CreditCardExpiration
        };

        _dbContext.PaymentDetails.Add(addCard);
        _dbContext.SaveChanges();

        return Ok(addCard);
    }
}