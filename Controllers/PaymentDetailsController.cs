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
    public IActionResult AddNewCard(PaymentDetailsForAddingCardDTO newCard)
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

    [HttpGet]
    public IActionResult GetAllByUserId(int id)
    {
        return Ok(_dbContext.PaymentDetails
        .Include(pd => pd.UserProfile)
        .Where(pd => pd.UserProfileId == id)
        .Select(pd => new PaymentDetailsDTO()
        {
            Id = pd.Id,
            UserProfileId = pd.UserProfileId,
            UserProfile = new UserProfileDTO()
            {
                Id = pd.UserProfile.Id,
                FirstName = pd.UserProfile.FirstName,
                LastName = pd.UserProfile.LastName,
                Address = pd.UserProfile.Address
            },
            CreditCardNumber = pd.CreditCardNumber,
            CreditCardExpiration = pd.CreditCardExpiration
        }).ToList());

    }
}